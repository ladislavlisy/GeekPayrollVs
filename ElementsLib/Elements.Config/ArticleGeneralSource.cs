using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config
{
    using BodyCode = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Codes;
    using Module.Interfaces.Elements;

    public abstract class ArticleGeneralSource : IArticleSource, ICloneable
    {
        public static string EXCEPTION_RESULT_NULL_TEXT = "Evaluate Results is not implemented!";
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

        public SourcePack CloneSourceAndSetValues<T>(ISourceValues values) where T : class, IArticleSource
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
        public virtual IEnumerable<ResultPack> EvaluateResults()
        {
            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(EXCEPTION_RESULT_NULL_TEXT) };
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
