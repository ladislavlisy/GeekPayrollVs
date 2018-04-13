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
    using Module.Libs;
    using Module.Items;
    using Module.Interfaces.Legalist;

    public abstract class ArticleGeneralSource : IArticleSource, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateDelegate(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults);

        public static string EXCEPTION_RESULT_NULL_TEXT = "Evaluate Results is not implemented!";
        public abstract string ArticleDecorateMessage(string message);
        public abstract void ImportSourceValues(ISourceValues values);
        public ArticleGeneralSource(BodyCode code)
        {
            InternalCode = code;

            InternalEvaluate = null;
        }

        protected BodyCode InternalCode { get; set; }

        protected EvaluateDelegate InternalEvaluate;
        public BodyCode Code()
        {
            return InternalCode;
        }

        public ISourceValues ExportSourceValues()
        {
            return null;
        }


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

        protected IEnumerable<ResultPack> ErrorToResults(string errorText)
        {
            return Result.Fail<IArticleResult, string>(errorText).ToList();
        }

        public virtual IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            if (InternalEvaluate == null)
            {
                return ErrorToResults(ArticleDecorateMessage(EXCEPTION_RESULT_NULL_TEXT));
            }
            return InternalEvaluate(evalTarget, evalPeriod, evalProfile, evalResults);
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
