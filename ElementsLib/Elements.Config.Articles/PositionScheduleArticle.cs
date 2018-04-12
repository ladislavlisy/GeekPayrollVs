using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionScheduleArticle : ArticleGeneralSource, ICloneable
    {
        public PositionScheduleArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_SCHEDULE)
        {
            SourceValues = new PositionScheduleSource();
        }

        public PositionScheduleArticle(ISourceValues values) : this()
        {
            PositionScheduleSource sourceValues = values as PositionScheduleSource;

            SourceValues = (PositionScheduleSource)sourceValues.Clone();
        }

        public PositionScheduleSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionScheduleSource>(values);
        }

        public override object Clone()
        {
            PositionScheduleArticle cloneArticle = (PositionScheduleArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
