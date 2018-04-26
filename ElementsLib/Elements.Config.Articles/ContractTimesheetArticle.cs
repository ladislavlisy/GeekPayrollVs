using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using TDay = Byte;
    using TSeconds = Int32;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using TargetErrs = String;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    using ValidsPack = ResultMonad.Result<bool, string>;
    using SourceItem = Sources.ContractTimesheetSource;

    using Sources;
    using Concepts;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Utils;
    using Results;
    using Legalist.Constants;
    using Module.Codes;
    using System.Linq;
    using ResultMonad.Extensions.ResultWithValueAndErrorMonad.OnSuccess;
    using MaybeMonad;

    public class ContractTimesheetArticle : GeneralArticle, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateConceptDelegate(ConfigCode evalCode, Period evalPeriod, IPeriodProfile evalProfile, Result<EvaluateSource, string> prepValues);

        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "ContractTimesheetArticle(ARTICLE_CONTRACT_TIMESHEET, 2): {0}";

        public ContractTimesheetArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_TIMESHEET)
        {
            SourceValues = new ContractTimesheetSource();

            InternalEvaluate = ContractTimesheetConcept.EvaluateConcept;
        }

        public ContractTimesheetArticle(ISourceValues values) : this()
        {
            ContractTimesheetSource sourceValues = values as ContractTimesheetSource;

            SourceValues = CloneUtils<ContractTimesheetSource>.CloneOrNull(sourceValues);
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

        public ContractTimesheetSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractTimesheetSource>(values);
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
            ContractTimesheetArticle cloneArticle = (ContractTimesheetArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalEvaluate = this.InternalEvaluate;

            return cloneArticle;
        }

        public class EvaluateSource
        {
            public class PositionSortItem
            {
                public PositionSortItem()
                {
                    PositionPart = 0;
                    DateFrom = null;
                    DateStop = null;
                    PositionType = WorkPositionType.POSITION_EXCLUSIVE;
                }
                public TargetPart PositionPart { get; set; }
                public DateTime? DateFrom { get; set; }
                public DateTime? DateStop { get; set; }
                public WorkPositionType PositionType { get; set; }

            }
            public class WorkTimesheetItem
            {
                public WorkTimesheetItem()
                {
                    PositionPart = 0;
                    ScheduleMonth = new TSeconds[0];
                    ScheduleTract = new TSeconds[0];
                }
                public TargetPart PositionPart { get; set; }
                public TSeconds[] ScheduleMonth { get; set; }
                public TSeconds[] ScheduleTract { get; set; }
            }
            internal class ComparePositionTerms : IComparer<PositionSortItem>
            {
                public int CompareDate(DateTime? x, DateTime? y)
                {
                    if (x.HasValue && y.HasValue)
                    {
                        DateTime xv = x.Value;
                        DateTime yv = y.Value;

                        return xv.CompareTo(yv);
                    }
                    else if (x.HasValue)
                    {
                        return 1;
                    }
                    else if (y.HasValue)
                    {
                        return -1;
                    }
                    return 0;
                }
                public int Compare(PositionSortItem x, PositionSortItem y)
                {
                    int compareFrom = CompareDate(x.DateFrom, y.DateFrom);
                    if (compareFrom == 0)
                    {
                        int compareStop = CompareDate(x.DateStop, y.DateStop);
                        if (compareStop == 0)
                        {
                            return x.PositionPart.CompareTo(y.PositionPart);
                        }
                        return compareStop;
                    }
                    return compareFrom;
                }
            }

            // PROPERTIES DEF
            IList<PositionSortItem> PositionList { get; set; }
            IDictionary<TargetPart, WorkTimesheetItem> TimesheetList { get; set; }
            // PROPERTIES DEF
            public class SourceBuilder : EvalValuesSourceBuilder<EvaluateSource>
            {
                public SourceBuilder(ISourceValues evalValues) : base(evalValues)
                {
                }

                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
                    // PROPERTIES SET
                    // PROPERTIES SET
                    return initValues;
                }
            }
            public class ResultBuilder : EvalValuesResultBuilder<EvaluateSource>
            {
                public ResultBuilder(TargetItem evalTarget, IEnumerable<ResultPair> evalResults) : base(evalTarget, evalResults)
                {
                }

                protected ResultMonad.Result<PositionSortItem, string> BuildPositionSortItem(ResultPair resultPair)
                {
                    TargetItem resultNode = resultPair.Key;
                    ResultPack resultPack = resultPair.Value;

                    if (resultPack.IsFailure)
                    {
                        return Result.Fail<PositionSortItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    ArticleGeneralResult typeResult = resultPack.Value as ArticleGeneralResult;
                    if (typeResult == null)
                    {
                        return Result.Fail<PositionSortItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    Maybe<TermFromStopPositionValue> termResult = typeResult.ReturnPositionTermFromStopValue();
                    if (termResult.HasNoValue)
                    {
                        return Result.Fail<PositionSortItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    TermFromStopPositionValue termValues = termResult.Value;

                    PositionSortItem buildResult = new PositionSortItem
                    {
                        PositionPart = resultNode.Seed(),
                        DateFrom = termValues.DateFrom,
                        DateStop = termValues.DateStop,
                        PositionType = termValues.PositionType
                    };
                    return Result.Ok<PositionSortItem, string>(buildResult);
                }
                protected ResultMonad.Result<IEnumerable<PositionSortItem>, string> BuildPositionSortList(TargetItem target, IEnumerable<ResultPair> results)
                {
                    ConfigCode positionCode = (ConfigCode)ArticleCodeCz.FACT_POSITION_TERM;

                    IEnumerable<ResultPair> positionList = results.GetResultForCodePlusHead(positionCode, target.Head());

                    return positionList.ToResultWithValueListAndError((s) => BuildPositionSortItem(s));
                }
                protected ResultMonad.Result<WorkTimesheetItem, string> BuildWorkScheduleItem(ResultPair resultPair)
                {
                    TargetItem resultNode = resultPair.Key;
                    ResultPack resultPack = resultPair.Value;

                    if (resultPack.IsFailure)
                    {
                        return Result.Fail<WorkTimesheetItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    ArticleGeneralResult typeResult = resultPack.Value as ArticleGeneralResult;
                    if (typeResult == null)
                    {
                        return Result.Fail<WorkTimesheetItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    Maybe<WorkMonthResultValue> realResult = typeResult.ReturnRealMonthValue();
                    if (realResult.HasNoValue)
                    {
                        return Result.Fail<WorkTimesheetItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    Maybe<WorkMonthResultValue> termResult = typeResult.ReturnTermMonthValue();
                    if (termResult.HasNoValue)
                    {
                        return Result.Fail<WorkTimesheetItem, string>(CONCEPT_RESULT_INVALID_TEXT);
                    }
                    WorkMonthResultValue realValues = realResult.Value;
                    WorkMonthResultValue termValues = termResult.Value;

                    WorkTimesheetItem buildResult = new WorkTimesheetItem
                    {
                        PositionPart = resultNode.Part(),
                        ScheduleMonth = realValues.HoursMonth,
                        ScheduleTract = termValues.HoursMonth
                    };
                    return Result.Ok<WorkTimesheetItem, string>(buildResult);
                }
                protected ResultMonad.Result<IEnumerable<WorkTimesheetItem>, string> BuildWorkScheduleList(TargetItem target, IEnumerable<ResultPair> results)
                {
                    ConfigCode positionCode = (ConfigCode)ArticleCodeCz.FACT_POSITION_TIMESHEET;

                    IEnumerable<ResultPair> positionList = results.GetResultForCodePlusHead(positionCode, target.Head());

                    return positionList.ToResultWithValueListAndError((s) => BuildWorkScheduleItem(s));
                }
                public override EvaluateSource GetNewValues(EvaluateSource initValues)
                {
                    var positionResult = BuildPositionSortList(InternalTarget, InternalValues);
                    var scheduleResult = BuildWorkScheduleList(InternalTarget, InternalValues);

                    if (positionResult.IsFailure)
                    {
                        return ReturnFailureAndError(initValues, positionResult.Error);
                    }
                    if (scheduleResult.IsFailure)
                    {
                        return ReturnFailureAndError(initValues, scheduleResult.Error);
                    }

                    var positionSorted = positionResult.Value.OrderBy((p) => (p), new ComparePositionTerms());
                    var scheduleInDict = scheduleResult.Value.ToDictionary((kv) => (kv.PositionPart), (kv) => (kv));

                    return new EvaluateSource
                    {
                        // PROPERTIES SET
                        PositionList = positionSorted.ToList(),
                        TimesheetList = scheduleInDict.ToDictionary((kv) => (kv.Key), (kv) => (kv.Value))
                        // PROPERTIES SET
                    };
                }
            }
        }
    }
}
