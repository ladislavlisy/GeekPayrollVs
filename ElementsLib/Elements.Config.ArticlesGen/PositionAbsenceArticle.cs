using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionAbsenceArticle : ArticleGeneralSource, ICloneable
    {
        public PositionAbsenceArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_ABSENCE)
        {
            SourceValues = new PositionAbsenceSource();
        }

        public PositionAbsenceArticle(ISourceValues values) : this()
        {
            PositionAbsenceSource sourceValues = values as PositionAbsenceSource;

            SourceValues = (PositionAbsenceSource)sourceValues.Clone();
        }

        public PositionAbsenceSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            PositionAbsenceSource sourceValues = values as PositionAbsenceSource;

            SourceValues = (PositionAbsenceSource)sourceValues.Clone();
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            PositionAbsenceArticle cloneArticle = (PositionAbsenceArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            PositionAbsenceArticle cloneArticle = (PositionAbsenceArticle)this.MemberwiseClone();

            clone.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}