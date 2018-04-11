using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionWorkingArticle : ArticleGeneralSource, ICloneable
    {
        public PositionWorkingArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_WORKING)
        {
            SourceValues = new PositionWorkingSource();
        }

        public PositionWorkingArticle(ISourceValues values) : this()
        {
            PositionWorkingSource sourceValues = values as PositionWorkingSource;

            SourceValues = (PositionWorkingSource)sourceValues.Clone();
        }

        public PositionWorkingSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionWorkingSource>(values);
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            PositionWorkingArticle cloneArticle = (PositionWorkingArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            PositionWorkingArticle cloneArticle = (PositionWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
