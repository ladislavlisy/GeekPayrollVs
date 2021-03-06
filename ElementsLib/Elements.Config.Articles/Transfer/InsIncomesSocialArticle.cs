using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;
    using ConfigBase = Module.Interfaces.Matrixus.IArticleConfigFeatures;
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using TargetErrs = String;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    using ValidsPack = ResultMonad.Result<bool, string>;
    using SourceItem = Sources.TaxIncomesGeneralSource;
    using ResultType = Results.ArticleGeneralResult;

    using TAmountDec = Decimal;

    using Sources;
    using Concepts;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Utils;
    using Results;
    using Legalist.Constants;
    using Module.Interfaces.Matrixus;
    using Module.Codes;
    using Matrixus.Config;
    using Module.Items.Utils;

    public class InsIncomesSocialArticle : GeneralArticle, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateConceptDelegate(ConfigBase evalConfig, Period evalPeriod, IPeriodProfile evalProfile, Result<EvaluateSource, string> prepValues);

        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "InsIncomesSocialArticle(ARTICLE_INS_INCOMES_SOCIAL, 1010): {0}";

        public InsIncomesSocialArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_INS_INCOMES_SOCIAL)
        {
            SourceValues = new InsIncomesSocialSource();

            InternalEvaluate = InsIncomesSocialConcept.EvaluateConcept;
        }

        public InsIncomesSocialArticle(ISourceValues values) : this()
        {
            InsIncomesSocialSource sourceValues = values as InsIncomesSocialSource;

            SourceValues = CloneUtils<InsIncomesSocialSource>.CloneOrNull(sourceValues);
        }

        protected EvaluateConceptDelegate InternalEvaluate { get; set; }

        protected override IEnumerable<ResultPack> EvaluateArticleResults(TargetItem evalTarget, ConfigBase evalConfig, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            if (InternalEvaluate == null)
            {
                return EvaluateUtils.DecoratedError(ARTICLE_DESCRIPTION_ERROR_FORMAT, EXCEPTION_RESULT_NONE_TEXT);
            }
            var sourceBuilder = new EvaluateSource.SourceBuilder(evalValues);
            var resultBuilder = new EvaluateSource.ResultBuilder(evalTarget, evalResults);

            var bundleValues = PrepareConceptValues<EvaluateSource>(sourceBuilder, resultBuilder);
            if (bundleValues.IsFailure)
            {
                return EvaluateUtils.DecoratedError(ARTICLE_DESCRIPTION_ERROR_FORMAT, bundleValues.Error);
            }
            return InternalEvaluate(evalConfig, evalPeriod, evalProfile, bundleValues);
        }

        public InsIncomesSocialSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<InsIncomesSocialSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format(ARTICLE_DESCRIPTION_ERROR_FORMAT, message);
        }

        public override object Clone()
        {
            InsIncomesSocialArticle cloneArticle = (InsIncomesSocialArticle)this.MemberwiseClone();

            cloneArticle.InternalConfig = CloneUtils<IArticleConfigFeatures>.CloneOrNull(this.InternalConfig);
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalEvaluate = this.InternalEvaluate;

            return cloneArticle;
        }

        public class EvaluateSource
        {
            public EvaluateSource()
            {
                SummarizeType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;
                IncludeIncome = decimal.Zero;
                ExcludeIncome = decimal.Zero;
            }
            // PROPERTIES DEF
            public WorkSocialTerms SummarizeType { get; set; }
            public TAmountDec IncludeIncome { get; set; }
            public TAmountDec ExcludeIncome { get; set; }
            // PROPERTIES DEF
            public class SourceBuilder : EvalValuesSourceBuilder<EvaluateSource>
            {
                public SourceBuilder(ISourceValues evalValues) : base(evalValues)
                {
                }

                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
#if GET_SOURCE_VALUE
                    SourceItem conceptValues = InternalValues as SourceItem;
                    if (conceptValues == null)
                    {
                        return ReturnFailure(initValues);
                    }
                    return new EvaluateSource
                    {
                        // PROPERTIES SET
                        // PROPERTIES SET
                    };
#else
                    return initValues;
#endif
                }
            }
            public class ResultBuilder : EvalValuesResultBuilder<EvaluateSource>
            {
                public ResultBuilder(TargetItem evalTarget, IEnumerable<ResultPair> evalResults) : base(evalTarget, evalResults)
                {
                }

                private Result<MoneyPaymentSum, string> GetIncludeIncome(IEnumerable<ResultPair> results, TargetItem target)
                {
                    Result<MoneyPaymentSum, string> taxableIncome = GetSumResultUtils.GetSumMoneyPayment(results,
                        TargetFilters.TargetHeadFunc(target.Head()), ArticleFilters.InsIncomeSocialFunc);

                    return taxableIncome;
                }
                private Result<MoneyPaymentSum, string> GetExcludeIncome(IEnumerable<ResultPair> results, TargetItem target)
                {
                    Result<MoneyPaymentSum, string> taxableIncome = GetSumResultUtils.GetSumMoneyPayment(results,
                        TargetFilters.TargetHeadFunc(target.Head()), ArticleFilters.InsExcludeSocialFunc);

                    return taxableIncome;
                }
                private Result<MoneyPaymentSum, string> GetSumPayments(MoneyPaymentSum agr, TargetItem resultTarget, MoneyPaymentValue resultValue)
                {
                    return Result.Ok<MoneyPaymentSum, string>(agr.Aggregate(resultValue.Payment));
                }
                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
                    ConfigCode declaracyCode = (ConfigCode)ArticleCodeCz.FACT_INS_DECLARATION_SOCIAL;

                    Result<DeclarationSocialValue, string> declaracyResult = InternalValues
                        .FindResultValue<ArticleGeneralResult, DeclarationSocialValue>(
                            TargetFilters.TargetCodePlusHeadAndNullPartFunc(declaracyCode, InternalTarget.Head()),
                            (x) => (x.IsDeclarationSocialValue()));

                    Result<MoneyPaymentSum, string> includeIncome = GetIncludeIncome(InternalValues, InternalTarget);
                    Result<MoneyPaymentSum, string> excludeIncome = GetExcludeIncome(InternalValues, InternalTarget);

                    if (ResultMonadUtils.HaveAnyResultFailed(declaracyResult, includeIncome, excludeIncome))
                    {
                        return ReturnFailureAndError(initValues,
                            ResultMonadUtils.FirstFailedResultError(declaracyResult, includeIncome, excludeIncome));
                    }

                    DeclarationSocialValue declaracyValues = declaracyResult.Value;

                    MoneyPaymentSum includeValues = includeIncome.Value;
                    MoneyPaymentSum excludeValues = excludeIncome.Value;

                    return new EvaluateSource
                    {
                        // PROPERTIES SET
                        SummarizeType = declaracyValues.SummarizeType,
                        IncludeIncome = includeValues.Balance(),
                        ExcludeIncome = excludeValues.Balance(),
                        // PROPERTIES SET
                    };
                }
            }
        }
    }
}
