using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Source;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Source;

    public class PositionTimesheetArticle : ArticleGeneralSource, ICloneable
    {
        public static string TARGET_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT = "PositionTimesheetArticle(4): Evaluate Results is not implemented!";

        public PositionTimesheetArticle() : base((ConfigCode)ConfigCodeEnum.TARGET_POSITION_TIMESHEET)
        {
            SourceValues = new PositionTimesheetSource();
        }

        public PositionTimesheetArticle(ISourceValues values) : this()
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

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("PositionTimesheetSource(TARGET_POSITION_TIMESHEET, 4): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(TARGET_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionTimesheetArticle cloneArticle = (PositionTimesheetArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
