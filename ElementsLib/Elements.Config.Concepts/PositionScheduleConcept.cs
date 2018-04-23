using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config.Concepts
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

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
    using Legalist.Constants;
    using ResultMonad;

    public static class PositionScheduleConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "PositionScheduleConcept(ARTICLE_POSITION_SCHEDULE, 3): {0}";
        public static string CONCEPT_RESULT_NONE_TEXT = "Evaluate Results is not implemented!";
        public static string CONCEPT_PROFILE_NULL_TEXT = "Employ profile is null!";
        public static string CONCEPT_VALUES_INVALID_TEXT = "Invalid source values!";
        public static string CONCEPT_RESULT_INVALID_TEXT = "Invalid dependent result values!";

        private class EvaluateStruct
        {
            public WorkScheduleType ScheduleType { get; set; }
            public TSeconds ShiftLiable { get; set; }
            public TSeconds ShiftActual { get; set; }
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
                return EvaluateUtils.DecoratedErrors(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);
            }

            EvaluateStruct mainValues = prepValues.Value;

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);

            if (mainValues.ScheduleType == WorkScheduleType.SCHEDULE_NORMALY_WEEK)
            {
                TSeconds[] hoursWeek = conceptProfile.TimesheetWeekSchedule(evalPeriod, mainValues.ShiftActual, 5);

                conceptResult.AddWorkWeekValue(hoursWeek);
            }
            else
            {
                return EvaluateUtils.DecoratedErrors(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_RESULT_NONE_TEXT);
            }
            return EvaluateUtils.Results(conceptResult);
        }
        private static ResultMonad.Result<EvaluateStruct, string> GetValuesFromSources(ISourceValues evalValues)
        {
            PositionScheduleSource conceptValues = evalValues as PositionScheduleSource;
            if (conceptValues == null)
            {
                return Result.Fail<EvaluateStruct, string>(CONCEPT_VALUES_INVALID_TEXT);
            }
            EvaluateStruct initValues = new EvaluateStruct
            {
                ScheduleType = conceptValues.ScheduleType,
                ShiftLiable = conceptValues.ShiftLiable,
                ShiftActual = conceptValues.ShiftActual
            };
            return Result.Ok<EvaluateStruct, string>(initValues);
        }
        private static ResultMonad.Result<EvaluateStruct, string> GetValuesFromResults(
            ResultMonad.Result<EvaluateStruct, string> initValues,
            TargetItem evalTarget, IEnumerable<ResultPair> evalResults)
        {
            return initValues;
        }
    }
}
