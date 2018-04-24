using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config.Concepts
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;

    using TDay = Byte;

    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Utils;
    using Sources;
    using Results;
    using Module.Codes;
    using ResultMonad;
    using MaybeMonad;

    public static class PositionTermConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "PositionTermConcept(ARTICLE_POSITION_TERM, 2): {0}";
        public static string CONCEPT_RESULT_NONE_TEXT = "Evaluate Results is not implemented!";
        public static string CONCEPT_PROFILE_NULL_TEXT = "Employ profile is null!";

        private class EvaluateStruct
        {
            public DateTime? DayTermFrom { get; set; }
            public DateTime? DayTermStop { get; set; }
            public TDay DayContractFrom { get; set; }
            public TDay DayContractStop { get; set; }

            public class SourceBuilder : EvalValuesSourceBuilder<EvaluateStruct>
            {
                public SourceBuilder(ISourceValues evalValues) : base(evalValues)
                {
                }

                public override EvaluateStruct GetNewValues(EvaluateStruct initValues)
                {
                    PositionTermSource conceptValues = InternalValues as PositionTermSource;
                    if (conceptValues == null)
                    {
                        return ReturnFailure(initValues);
                    }
                    return new EvaluateStruct
                    {
                        DayTermFrom = conceptValues.DateFrom,
                        DayTermStop = conceptValues.DateStop
                    };
                }
            }
            public class ResultBuilder : EvalValuesResultBuilder<EvaluateStruct>
            {
                public ResultBuilder(TargetItem evalTarget, IEnumerable<ResultPair> evalResults) : base(evalTarget, evalResults)
                {
                }

                public override EvaluateStruct GetNewValues(EvaluateStruct initValues)
                {
                    ConfigCode termCode = (ConfigCode)ArticleCodeCz.FACT_CONTRACT_TERM;

                    ResultPack termBundle = InternalValues.FindContractResultForCode(termCode, InternalTarget.Head());
                    if (termBundle.IsFailure)
                    {
                        return ReturnFailureAndError(initValues, termBundle.Error);
                    }
                    ArticleGeneralResult termResult = termBundle.Value as ArticleGeneralResult;
                    if (termResult == null)
                    {
                        return ReturnFailure(initValues);
                    }
                    Maybe<MonthFromStopResultValue> termValues = termResult.ReturnValue<MonthFromStopResultValue>((v) => (v.IsMonthFromStopValue()));
                    if (termValues.HasNoValue)
                    {
                        return ReturnFailure(initValues);
                    }

                    MonthFromStopResultValue termValuesPrep = termValues.Value;

                    return new EvaluateStruct
                    {
                        DayTermFrom = initValues.DayTermFrom,
                        DayTermStop = initValues.DayTermStop,
                        DayContractFrom = termValuesPrep.PeriodDayFrom,
                        DayContractStop = termValuesPrep.PeriodDayStop
                    };
                }
            }
        }

        private static ResultMonad.Result<EvaluateStruct, string> PrepareConceptValues(TargetItem evalTarget, ISourceValues evalValues, IEnumerable<ResultPair> evalResults)
        {
            ResultMonad.Result<EvaluateStruct, string> initValues = Result.Ok<EvaluateStruct, string>(new EvaluateStruct());

            IList<EvalValuesBuilder<EvaluateStruct>> evalBuilders = new List<EvalValuesBuilder<EvaluateStruct>>()
            {
                new EvaluateStruct.SourceBuilder(evalValues),
                new EvaluateStruct.ResultBuilder(evalTarget, evalResults),
            };

            return evalBuilders.Aggregate(initValues, (agr, x) => (x.GetValues(agr)));
        }

        public static IEnumerable<ResultPack> EvaluateConcept(TargetItem evalTarget, ConfigCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            ResultMonad.Result<EvaluateStruct, string> prepValues = PrepareConceptValues(evalTarget, evalValues, evalResults);
            if (prepValues.IsFailure)
            {
                return EvaluateUtils.DecoratedError(CONCEPT_DESCRIPTION_ERROR_FORMAT, prepValues.Error);
            }
            IEmployProfile conceptProfile = evalProfile.Employ();
            if (conceptProfile == null)
            {
                return EvaluateUtils.DecoratedError(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);
            }

            EvaluateStruct conceptValues = prepValues.Value;

            TDay dayTermFrom = conceptProfile.DateFromInPeriod(evalPeriod, conceptValues.DayTermFrom);
            if (dayTermFrom < conceptValues.DayContractFrom)
            {
                dayTermFrom = conceptValues.DayContractFrom;
            }
            TDay dayTermStop = conceptProfile.DateStopInPeriod(evalPeriod, conceptValues.DayTermStop);
            if (dayTermStop > conceptValues.DayContractStop)
            {
                dayTermStop = conceptValues.DayContractStop;
            }

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);

            conceptResult.AddMonthFromStop(dayTermFrom, dayTermStop);

            return EvaluateUtils.Results(conceptResult);
        }

    }
}
