using System;

namespace ElementsLib.Elements.Config
{
    using BodyCode = UInt16;

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

        public T SetSourceValues<T>(ISourceValues values) where T : class, ICloneable
        {
            T sourceValues = values as T;

            if (sourceValues == null)
            {
                return null;
            }
            return (T)sourceValues.Clone();
        }

        public ResultMonad.Result<IArticleSource, string> CloneSourceAndSetValues<T>(ISourceValues values) where T : class, IArticleSource
        {
            T cloneArticle = (T)Clone();

            try
            {
                cloneArticle.ImportSourceValues(values);
            }
            catch (Exception e)
            {
                return ResultMonad.Result.Fail<IArticleSource, string>(e.ToString());
            }

            return ResultMonad.Result.Ok<IArticleSource, string>(cloneArticle);
        }

        public virtual object Clone()
        {
            ArticleGeneralSource cloneArticle = (ArticleGeneralSource)this.MemberwiseClone();
            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }
        public override string ToString()
        {
            return ArticleCodeAdapter.GetSymbol(InternalCode);
        }
    }
}
