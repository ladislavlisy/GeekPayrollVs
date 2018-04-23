using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config.Concepts
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using TDay = Byte;
    using TSeconds = Int32;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;

    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Utils;
    using Sources;
    using Results;
    using Module.Codes;
    using MaybeMonad;
    using ResultMonad;

    public static class PositionTimesheetConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "PositionTimesheetConcept(ARTICLE_POSITION_TIMESHEET, 4): {0}";
        public static string CONCEPT_RESULT_NONE_TEXT = "Evaluate Results is not implemented!";
        public static string CONCEPT_PROFILE_NULL_TEXT = "Employ profile is null!";
        public static string CONCEPT_VALUES_INVALID_TEXT = "Invalid source values!";
        public static string CONCEPT_RESULT_INVALID_TEXT = "Invalid dependent result values!";

        private class EvaluateStruct
        {
            public TDay DayTermFrom { get; set; }
            public TDay DayTermStop { get; set; }
            public TSeconds[] WorkWeekHours { get; set; }
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
                return EvaluateUtils.DecoratedError(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);
            }

            EvaluateStruct mainValues = prepValues.Value;

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);

            TSeconds[] scheduleFullMonth = conceptProfile.TimesheetFullSchedule(evalPeriod, mainValues.WorkWeekHours);
            TSeconds[] scheduleTermMonth = conceptProfile.TimesheetWorkSchedule(evalPeriod, scheduleFullMonth, mainValues.DayTermFrom, mainValues.DayTermStop);

            //conceptResult.AddWorkMonthFullScheduleValue(scheduleFullMonth);
            //conceptResult.AddWorkMonthTermScheduleValue(scheduleTermMonth);

            return EvaluateUtils.Results(conceptResult);
        }

        public static IEnumerable<ResultPack> ConceptDecorateResultError(string message)
        {
            string conceptMessage = string.Format(CONCEPT_DESCRIPTION_ERROR_FORMAT, message);

            return EvaluateUtils.Error(conceptMessage);
        }
        private static ResultMonad.Result<EvaluateStruct, string> GetValuesFromSources(ISourceValues evalValues)
        {
            EvaluateStruct initValues = new EvaluateStruct();

            return Result.Ok<EvaluateStruct, string>(initValues);
        }
        private static ResultMonad.Result<EvaluateStruct, string> GetValuesFromResults(
            ResultMonad.Result<EvaluateStruct, string> initValues,
            TargetItem evalTarget, IEnumerable<ResultPair> evalResults)
        {
            if (initValues.IsFailure)
            {
                return initValues;
            }
            ResultPack workResultPack = evalResults.FindResultForCodePlusPart((ConfigCode)ArticleCodeCz.FACT_POSITION_SCHEDULE, evalTarget.Head(), evalTarget.Part());
            if (workResultPack.IsFailure)
            {
                return Result.Fail<EvaluateStruct, string>(workResultPack.Error);
            }
            ArticleGeneralResult workResultItem = workResultPack.Value as ArticleGeneralResult;
            if (workResultItem == null)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_RESULT_INVALID_TEXT);
            }
            Maybe<WorkWeekResultValue> workResultVals = workResultItem.ReturnValue<WorkWeekResultValue>((v) => (v.IsWorkWeekValue()));
            if (workResultVals.HasNoValue)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_RESULT_INVALID_TEXT);
            }
            WorkWeekResultValue workResultPrep = workResultVals.Value;

            ResultPack termResultPack = evalResults.FindPositionResultForCode((ConfigCode)ArticleCodeCz.FACT_POSITION_TERM, evalTarget.Head(), evalTarget.Part());
            if (termResultPack.IsFailure)
            {
                return Result.Fail<EvaluateStruct, string>(termResultPack.Error);
            }
            ArticleGeneralResult termResultItem = termResultPack.Value as ArticleGeneralResult;
            if (termResultItem == null)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_RESULT_INVALID_TEXT);
            }
            Maybe<MonthFromStopResultValue> termResultVals = termResultItem.ReturnValue<MonthFromStopResultValue>((v) => (v.IsWorkWeekValue()));
            if (termResultVals.HasNoValue)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_RESULT_INVALID_TEXT);
            }
            MonthFromStopResultValue termResultPrep = termResultVals.Value;

            EvaluateStruct succValues = initValues.Value;
            EvaluateStruct prepValues = new EvaluateStruct
            {
                DayTermFrom = termResultPrep.PeriodDayFrom,
                DayTermStop = termResultPrep.PeriodDayStop,
                WorkWeekHours = workResultPrep.HoursWeek
            };
            return Result.Ok<EvaluateStruct, string>(prepValues);
        }
    }
}
