using System;

namespace ElementsLib.Elements.Config.Articles
{
    using SymbolCode = Module.Codes.ArticleCzCode;
    using SourceCode = UInt16;
    using Module.Interfaces.Elements;

    public class UnknownArticle : ArticleGeneralSource, ICloneable
    {
        public UnknownArticle() : base((SourceCode)SymbolCode.ARTCODE_UNKNOWN)
        {
        }

        public override void ImportSourceValues(ISourceValues values)
        {
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            UnknownArticle cloneArticle = (UnknownArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            UnknownArticle clone = (UnknownArticle)this.MemberwiseClone();
            clone.InternalCode = this.InternalCode;

            return clone;
        }

    }
}
