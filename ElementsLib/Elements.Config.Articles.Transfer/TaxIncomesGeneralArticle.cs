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

    using TAmount = Decimal;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using TargetErrs = String;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    using ValidsPack = ResultMonad.Result<bool, string>;
    using SourceItem = Sources.TaxIncomesGeneralSource;
    using ResultType = Results.ArticleGeneralResult;

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
    using Module.Items.Utils;
    using Matrixus.Config;

    public class TaxIncomesGeneralArticle : GeneralArticle, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateConceptDelegate(ConfigBase evalConfig, Period evalPeriod, IPeriodProfile evalProfile, Result<EvaluateSource, string> prepValues);

        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "TaxIncomesGeneralArticle(ARTICLE_TAX_INCOMES_GENERAL, 1004): {0}";

        public TaxIncomesGeneralArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_TAX_INCOMES_GENERAL)
        {
            SourceValues = new TaxIncomesGeneralSource();

            InternalEvaluate = TaxIncomesGeneralConcept.EvaluateConcept;
        }

        public TaxIncomesGeneralArticle(ISourceValues values) : this()
        {
            TaxIncomesGeneralSource sourceValues = values as TaxIncomesGeneralSource;

            SourceValues = CloneUtils<TaxIncomesGeneralSource>.CloneOrNull(sourceValues);
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

        public TaxIncomesGeneralSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<TaxIncomesGeneralSource>(values);
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
            TaxIncomesGeneralArticle cloneArticle = (TaxIncomesGeneralArticle)this.MemberwiseClone();

            cloneArticle.InternalConfig = CloneUtils<IArticleConfigFeatures>.CloneOrNull(this.InternalConfig);
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalEvaluate = this.InternalEvaluate;

            return cloneArticle;
        }

        public class EvaluateSource
        {
            public EvaluateSource()
            {
                SummarizeType = WorkTaxingTerms.TAXING_TERM_EMPLOYMENT_POLICY;
                StatementType = 0;
                DeclaracyType = 0;
                ResidencyType = 0;
                TaxableIncome = decimal.Zero;
                PartnerIncome = decimal.Zero;
                ExcludeIncome = decimal.Zero;
            }
            // PROPERTIES DEF
            public WorkTaxingTerms SummarizeType { get; set; }
            public Byte StatementType { get; set; }
            public Byte DeclaracyType { get; set; }
            public Byte ResidencyType { get; set; }
            public TAmount TaxableIncome { get; set; }
            public TAmount PartnerIncome { get; set; }
            public TAmount ExcludeIncome { get; set; }
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

                private Result<MoneyPaymentSum, string> GetTaxableIncome(IEnumerable<ResultPair> results, TargetItem target)
                {
                    MoneyPaymentSum initBalance = new MoneyPaymentSum(decimal.Zero);

                    Result<MoneyPaymentSum, string> taxableIncome = results
                        .GetResultValuesInAggrAndError<ResultItem, MoneyPaymentValue, MoneyPaymentSum>(
                            initBalance, TargetFilters.TargetHeadFunc(target.Head()), ArticleFilters.TaxIncomeFunc, 
                            ResultFilters.PaymentMoneyFunc, GetSumPayments);

                    return taxableIncome;
                }
                private Result<MoneyPaymentSum, string> GetPartnerIncome(IEnumerable<ResultPair> results, TargetItem target)
                {
                    MoneyPaymentSum initBalance = new MoneyPaymentSum(decimal.Zero);

                    Result<MoneyPaymentSum, string> taxableIncome = results
                        .GetResultValuesInAggrAndError<ResultItem, MoneyPaymentValue, MoneyPaymentSum>(
                            initBalance, TargetFilters.TargetHeadFunc(target.Head()), ArticleFilters.TaxPartnerFunc, 
                            ResultFilters.PaymentMoneyFunc, GetSumPayments);

                    return taxableIncome;
                }

                private Result<MoneyPaymentSum, string> GetExcludeIncome(IEnumerable<ResultPair> results, TargetItem target)
                {
                    MoneyPaymentSum initBalance = new MoneyPaymentSum(decimal.Zero);

                    Result<MoneyPaymentSum, string> taxableIncome = results
                        .GetResultValuesInAggrAndError<ResultItem, MoneyPaymentValue, MoneyPaymentSum>(
                            initBalance, TargetFilters.TargetHeadFunc(target.Head()), ArticleFilters.TaxExcludeFunc, 
                            ResultFilters.PaymentMoneyFunc, GetSumPayments);

                    return taxableIncome;
                }

                private Result<MoneyPaymentSum, string> GetSumPayments(MoneyPaymentSum agr, TargetItem resultTarget, MoneyPaymentValue resultValue)
                {
                    return Result.Ok<MoneyPaymentSum, string>(agr.Aggregate(resultValue.Payment));
                }

                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
                    ConfigCode declaracyCode = (ConfigCode)ArticleCodeCz.FACT_TAX_DECLARATION;

                    Result<DeclarationTaxingValue, string> declaracyResult = InternalValues
                        .FindResultValue<ArticleGeneralResult, DeclarationTaxingValue>(
                            TargetFilters.TargetCodePlusHeadAndNullPartFunc(declaracyCode, InternalTarget.Head()),
                            (x) => (x.IsDeclarationTaxingValue()));

                    Result<MoneyPaymentSum, string> taxableIncome = GetTaxableIncome(InternalValues, InternalTarget);
                    Result<MoneyPaymentSum, string> partnerIncome = GetPartnerIncome(InternalValues, InternalTarget);
                    Result<MoneyPaymentSum, string> excludeIncome = GetExcludeIncome(InternalValues, InternalTarget);

                    if (ResultMonadUtils.HaveAnyResultFailed(declaracyResult, taxableIncome, partnerIncome))
                    {
                        return ReturnFailureAndError(initValues, 
                            ResultMonadUtils.FirstFailedResultError(declaracyResult, taxableIncome, partnerIncome));
                    }

                    DeclarationTaxingValue declaracyValues = declaracyResult.Value;

                    MoneyPaymentSum taxableValues = taxableIncome.Value;
                    MoneyPaymentSum partnerValues = partnerIncome.Value;
                    MoneyPaymentSum excludeValues = excludeIncome.Value;

                    return new EvaluateSource
                    {
                        // PROPERTIES SET
                        SummarizeType = declaracyValues.SummarizeType,
                        StatementType = declaracyValues.StatementType,
                        DeclaracyType = declaracyValues.DeclaracyType,
                        ResidencyType = declaracyValues.ResidencyType,
                        TaxableIncome = taxableValues.Balance(),
                        PartnerIncome = partnerValues.Balance(),
                        ExcludeIncome = excludeValues.Balance(),
                        // PROPERTIES SET
                    };
                }
            }
        }
    }
}
