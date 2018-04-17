using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Targets
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using TargetPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleTarget, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Target;

    public class PositionTimesheetTarget : ArticleGeneralTarget, ICloneable
    {
        public static string TARGET_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT = "PositionTimesheetTarget(4): Evaluate Results is not implemented!";

        public PositionTimesheetTarget() : base((ConfigCode)ConfigCodeEnum.TARGET_POSITION_TIMESHEET)
        {
            SourceValues = new PositionTimesheetSource();
        }

        public PositionTimesheetTarget(ISourceValues values) : this()
        {
            PositionTimesheetSource sourceValues = values as PositionTimesheetSource;

            SourceValues = (PositionTimesheetSource)sourceValues.Clone();
        }

        public PositionTimesheetSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionTimesheetSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string TargetDecorateMessage(string message)
        {
            return string.Format("PositionTimesheetSource(TARGET_POSITION_TIMESHEET, 4): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(TARGET_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionTimesheetTarget cloneArticle = (PositionTimesheetTarget)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalType = this.InternalType;
            cloneArticle.InternalPath = this.InternalPath.ToList();

            return cloneArticle;
        }

    }
}
