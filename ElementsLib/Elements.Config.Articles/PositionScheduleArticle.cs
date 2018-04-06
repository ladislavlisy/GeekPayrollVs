using System;

namespace ElementsLib.Elements.Config.Articles
{
    using SymbolCode = Module.Codes.ArticleCzCode;
    using SourceCode = UInt16;
    using Source;
    using Module.Interfaces.Elements;

    public class PositionScheduleArticle : ArticleGeneralSource, ICloneable
    {
        public PositionScheduleArticle() : base((SourceCode)SymbolCode.ARTCODE_POSITION_SCHEDULE)
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
            PositionScheduleSource sourceValues = values as PositionScheduleSource;

            SourceValues = (PositionScheduleSource)sourceValues.Clone();
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            PositionScheduleArticle cloneArticle = (PositionScheduleArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            PositionScheduleArticle clone = (PositionScheduleArticle)this.MemberwiseClone();
            clone.InternalCode = this.InternalCode;

            return clone;
        }
    }
}
