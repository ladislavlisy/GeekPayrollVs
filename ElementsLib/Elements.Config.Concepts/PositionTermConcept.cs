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
        public static string CONCEPT_VALUES_INVALID_TEXT = "Invalid source values!";
        public static string CONCEPT_RESULT_INVALID_TEXT = "Invalid dependent result values!";

        private class EvaluateStruct
        {
            public DateTime? DayTermFrom { get; set; }
            public DateTime? DayTermStop { get; set; }
            public TDay DayContractFrom { get; set; }
            public TDay DayContractStop { get; set; }
        }

        public static IEnumerable<ResultPack> EvaluateConcept(TargetItem evalTarget, ConfigCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            ResultMonad.Result<EvaluateStruct, string> initValues = GetValuesFromSources(evalValues);
            if (initValues.IsFailure)
            {
                return EvaluateUtils.DecoratedErrors(initValues.Error,
                    CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_VALUES_INVALID_TEXT);
            }

            ResultMonad.Result<EvaluateStruct, string> prepValues = GetValuesFromResults(initValues, evalTarget, evalResults);
            if (prepValues.IsFailure)
            {
                return EvaluateUtils.DecoratedErrors(prepValues.Error,
                    CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_RESULT_INVALID_TEXT);
            }
            IEmployProfile conceptProfile = evalProfile.Employ();
            if (conceptProfile == null)
            {
                return ConceptDecorateResultError(CONCEPT_PROFILE_NULL_TEXT);
            }

            EvaluateStruct mainValues = prepValues.Value;

            TDay dayTermFrom = conceptProfile.DateFromInPeriod(evalPeriod, mainValues.DayTermFrom);
            if (dayTermFrom < mainValues.DayContractFrom)
            {
                dayTermFrom = mainValues.DayContractFrom;
            }
            TDay dayTermStop = conceptProfile.DateStopInPeriod(evalPeriod, mainValues.DayTermStop);
            if (dayTermStop > mainValues.DayContractStop)
            {
                dayTermStop = mainValues.DayContractStop;
            }

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);

            conceptResult.AddMonthFromStop(dayTermFrom, dayTermStop);

            return EvaluateUtils.Results(conceptResult);
        }

        public static IEnumerable<ResultPack> ConceptDecorateResultError(string message)
        {
            string conceptMessage = string.Format(CONCEPT_DESCRIPTION_ERROR_FORMAT, message);

            return EvaluateUtils.Error(conceptMessage);
        }
        private static ResultMonad.Result<EvaluateStruct, string> GetValuesFromSources(ISourceValues evalValues)
        {
            PositionTermSource conceptValues = evalValues as PositionTermSource;
            if (conceptValues == null)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_VALUES_INVALID_TEXT);
            }
            EvaluateStruct initValues = new EvaluateStruct
            {
                DayTermFrom = conceptValues.DateFrom, DayTermStop = conceptValues.DateStop
            };
            return Result.Ok<EvaluateStruct, string>(initValues);
        }
        private static ResultMonad.Result<EvaluateStruct, string> GetValuesFromResults(ResultMonad.Result<EvaluateStruct, string> initValues, 
            TargetItem evalTarget, IEnumerable<ResultPair> evalResults)
        {
            if (initValues.IsFailure)
            {
                return initValues;
            }
            ResultPack termResultPack = evalResults.FindContractResultForCode((ConfigCode)ArticleCodeCz.FACT_CONTRACT_TERM, evalTarget.Head());
            if (termResultPack.IsFailure)
            {
                return Result.Fail<EvaluateStruct, string>(termResultPack.Error);
            }
            ArticleGeneralResult termResultItem = termResultPack.Value as ArticleGeneralResult;
            if (termResultItem == null)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_RESULT_INVALID_TEXT);
            }
            Maybe<MonthFromStopResultValue> termResultVals = termResultItem.ReturnValue<MonthFromStopResultValue>((v) => (v.IsMonthFromStopValue()));
            if (termResultVals.HasNoValue)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_RESULT_INVALID_TEXT);
            }
            MonthFromStopResultValue termResultPrep = termResultVals.Value;

            EvaluateStruct succValues = initValues.Value;
            EvaluateStruct prepValues = new EvaluateStruct
            {
                DayTermFrom = succValues.DayTermFrom, DayTermStop = succValues.DayTermStop,
                DayContractFrom = termResultPrep.PeriodDayFrom,
                DayContractStop = termResultPrep.PeriodDayStop
            };

            return Result.Ok<EvaluateStruct, string>(prepValues);
        }
    }
}
