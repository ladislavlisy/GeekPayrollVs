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

        private class EvaluateStruct
        {
            public TDay DayTermFrom { get; set; }
            public TDay DayTermStop { get; set; }
            public TSeconds[] WorkWeekHours { get; set; }
            public class SourceBuilder : EvalValuesSourceBuilder<EvaluateStruct>
            {
                public SourceBuilder(ISourceValues evalValues) : base(evalValues)
                {
                }

                public override EvaluateStruct GetNewValues(EvaluateStruct initValues)
                {
                    return initValues;
                }
            }
            public class ResultBuilder : EvalValuesResultBuilder<EvaluateStruct>
            {
                public ResultBuilder(TargetItem evalTarget, IEnumerable<ResultPair> evalResults) : base(evalTarget, evalResults)
                {
                }

                public override EvaluateStruct GetNewValues(EvaluateStruct initValues)
                {
                    ConfigCode workCode = (ConfigCode)ArticleCodeCz.FACT_POSITION_SCHEDULE;

                    ResultPack workBundle = InternalValues.FindResultForCodePlusPart(workCode, InternalTarget.Head(), InternalTarget.Part());
                    if (workBundle.IsFailure)
                    {
                        return ReturnFailureAndError(initValues, workBundle.Error);
                    }
                    ArticleGeneralResult workResult = workBundle.Value as ArticleGeneralResult;
                    if (workResult == null)
                    {
                        return ReturnFailure(initValues);
                    }
                    Maybe<WorkWeekResultValue> workValues = workResult.ReturnValue<WorkWeekResultValue>((v) => (v.IsWorkWeekValue()));
                    if (workValues.HasNoValue)
                    {
                        return ReturnFailure(initValues);
                    }

                    WorkWeekResultValue workValuesPrep = workValues.Value;

                    ConfigCode termCode = (ConfigCode)ArticleCodeCz.FACT_POSITION_TERM;

                    ResultPack termBundle = InternalValues.FindPositionResultForCode(termCode, InternalTarget.Head(), InternalTarget.Part());
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
                        DayTermFrom = termValuesPrep.PeriodDayFrom,
                        DayTermStop = termValuesPrep.PeriodDayStop,
                        WorkWeekHours = workValuesPrep.HoursWeek
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

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);

            TSeconds[] scheduleFullMonth = conceptProfile.TimesheetFullSchedule(evalPeriod, conceptValues.WorkWeekHours);
            TSeconds[] scheduleTermMonth = conceptProfile.TimesheetWorkSchedule(evalPeriod, scheduleFullMonth, conceptValues.DayTermFrom, conceptValues.DayTermStop);

            //conceptResult.AddWorkMonthFullScheduleValue(scheduleFullMonth);
            //conceptResult.AddWorkMonthTermScheduleValue(scheduleTermMonth);

            return EvaluateUtils.Results(conceptResult);
        }

    }
}
