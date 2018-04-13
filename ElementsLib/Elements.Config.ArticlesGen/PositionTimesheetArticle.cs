using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionTimesheetArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT = "PositionTimesheetArticle(4): Evaluate Results is not implemented!";

        public PositionTimesheetArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_TIMESHEET)
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

        public override IEnumerable<ResultPack> EvaluateResults()
        {
            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(ARTCODE_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT) };
        }

        public override object Clone()
        {
            PositionTimesheetArticle cloneArticle = (PositionTimesheetArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
