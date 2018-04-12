using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionTimesheetArticle : ArticleGeneralSource, ICloneable
    {
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

        public override object Clone()
        {
            PositionTimesheetArticle cloneArticle = (PositionTimesheetArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
