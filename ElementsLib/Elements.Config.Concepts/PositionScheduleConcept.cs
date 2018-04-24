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

        private class EvaluateStruct
        {
            public WorkScheduleType ScheduleType { get; set; }
            public TSeconds ShiftLiable { get; set; }
            public TSeconds ShiftActual { get; set; }
            public class SourceBuilder : EvalValuesSourceBuilder<EvaluateStruct>
            {
                public SourceBuilder(ISourceValues evalValues) : base(evalValues)
                {
                }

                public override EvaluateStruct GetNewValues(EvaluateStruct initValues)
                {
                    PositionScheduleSource conceptValues = InternalValues as PositionScheduleSource;
                    if (conceptValues == null)
                    {
                        return ReturnFailure(initValues);
                    }
                    return new EvaluateStruct
                    {
                        ScheduleType = conceptValues.ScheduleType,
                        ShiftLiable = conceptValues.ShiftLiable,
                        ShiftActual = conceptValues.ShiftActual
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
                    return initValues;
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
                return EvaluateUtils.DecoratedErrors(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);
            }

            EvaluateStruct conceptValues = prepValues.Value;

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);

            if (conceptValues.ScheduleType == WorkScheduleType.SCHEDULE_NORMALY_WEEK)
            {
                TSeconds[] hoursWeek = conceptProfile.TimesheetWeekSchedule(evalPeriod, conceptValues.ShiftActual, 5);

                conceptResult.AddWorkWeekValue(hoursWeek);
            }
            else
            {
                return EvaluateUtils.DecoratedErrors(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_RESULT_NONE_TEXT);
            }
            return EvaluateUtils.Results(conceptResult);
        }
    }
}
