using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using TargetErrs = String;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;
    using SourceItem = Sources.UnknownSource;

    using Sources;
    using Concepts;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Utils;
    using Results;

    public class UnknownArticle : GeneralArticle, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateConceptDelegate(ConfigCode evalCode, Period evalPeriod, IPeriodProfile evalProfile, Result<EvaluateSource, string> prepValues);

        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "UnknownArticle(ARTICLE_UNKNOWN, 0): {0}";

        public UnknownArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_UNKNOWN)
        {
            SourceValues = new UnknownSource();

            InternalEvaluate = UnknownConcept.EvaluateConcept;
        }

        public UnknownArticle(ISourceValues values) : this()
        {
            UnknownSource sourceValues = values as UnknownSource;

            SourceValues = CloneUtils<UnknownSource>.CloneOrNull(sourceValues);
        }

        protected EvaluateConceptDelegate InternalEvaluate { get; set; }

        protected override IEnumerable<ResultPack> EvaluateArticleResults(TargetItem evalTarget, ConfigCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
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
            return InternalEvaluate(evalCode, evalPeriod, evalProfile, bundleValues);
        }

        public UnknownSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<UnknownSource>(values);
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
            UnknownArticle cloneArticle = (UnknownArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalEvaluate = this.InternalEvaluate;

            return cloneArticle;
        }

        public class EvaluateSource
        {
            // PROPERTIES DEF
            // public XXX ZZZ { get; set; }
            // PROPERTIES DEF
            public class SourceBuilder : EvalValuesSourceBuilder<EvaluateSource>
            {
                public SourceBuilder(ISourceValues evalValues) : base(evalValues)
                {
                }

                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
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
                }
            }
            public class ResultBuilder : EvalValuesResultBuilder<EvaluateSource>
            {
                public ResultBuilder(TargetItem evalTarget, IEnumerable<ResultPair> evalResults) : base(evalTarget, evalResults)
                {
                }

                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
                    // PROPERTIES SET
                    // PROPERTIES SET
                    return initValues;
                }
            }
        }
    }
}
