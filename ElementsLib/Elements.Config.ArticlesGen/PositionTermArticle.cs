using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionTermArticle : ArticleGeneralSource, ICloneable
    {
        public PositionTermArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_TERM)
        {
            SourceValues = new PositionTermSource();
        }

        public PositionTermArticle(ISourceValues values) : this()
        {
            PositionTermSource sourceValues = values as PositionTermSource;

            SourceValues = (PositionTermSource)sourceValues.Clone();
        }

        public PositionTermSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            PositionTermSource sourceValues = values as PositionTermSource;

            SourceValues = (PositionTermSource)sourceValues.Clone();
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            PositionTermArticle cloneArticle = (PositionTermArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            PositionTermArticle cloneArticle = (PositionTermArticle)this.MemberwiseClone();

            clone.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
