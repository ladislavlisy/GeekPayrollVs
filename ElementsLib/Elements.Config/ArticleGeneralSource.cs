using System;

namespace ElementsLib.Elements.Config
{
    using BodyCode = UInt16;
    using MarkCode = Module.Codes.ArticleCzCode;

    using Module.Codes;
    using Module.Interfaces.Elements;

    public abstract class ArticleGeneralSource : IArticleSource, ICloneable
    {
        public ArticleGeneralSource(BodyCode code)
        {
            InternalCode = code;
        }

        protected BodyCode InternalCode { get; set; }

        public BodyCode Code()
        {
            return InternalCode;
        }

        public ISourceValues ExportSourceValues()
        {
            return null;
        }

        public abstract void ImportSourceValues(ISourceValues values);

        public abstract IArticleSource CloneSourceAndSetValues(ISourceValues values);

        public virtual object Clone()
        {
            ArticleGeneralSource cloneArticle = (ArticleGeneralSource)this.MemberwiseClone();
            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }
        public override string ToString()
        {
            MarkCode symbol = ArticleCodeAdapter.CreateEnum(InternalCode);

            return symbol.GetSymbol();
        }
    }
}
