﻿using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config
{
    using TargetCode = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Codes;
    using Module.Interfaces.Elements;
    using Module.Libs;
    using Module.Items;
    using Module.Interfaces.Legalist;
    using System.Linq;

    public abstract class ArticleGeneralSource : IArticleSource, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateDelegate(TargetItem evalTarget, TargetCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults);

        public static string EXCEPTION_RESULT_NULL_TEXT = "Evaluate Results is not implemented!";
        public static string EXCEPTION_VALUES_NULL_TEXT = "Source values are null!";
        public static string EXCEPTION_EXPERT_NULL_TEXT = "Expert profile is null!";
        public abstract string ArticleDecorateMessage(string message);
        public abstract void ImportSourceValues(ISourceValues values);
        public abstract ISourceValues ExportSourceValues();
        public ArticleGeneralSource(TargetCode code)
        {
            InternalCode = code;

            InternalEvaluate = null;
        }

        protected TargetCode InternalCode { get; set; }

        protected EvaluateDelegate InternalEvaluate;
        public TargetCode Code()
        {
            return InternalCode;
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

        protected IEnumerable<ResultPack> ErrorToResults(params string[] errorText)
        {
            return errorText.Select((e) => (Result.Fail<IArticleResult, string>(e))).ToList();
        }

        protected IEnumerable<ResultPack> ResultsToList(params ResultPack[] results)
        {
            return results.Select((r) => (r)).ToList();
        }

        public virtual IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            if (InternalEvaluate == null)
            {
                return ErrorToResults(ArticleDecorateMessage(EXCEPTION_RESULT_NULL_TEXT));
            }
            ISourceValues evalValues = ExportSourceValues();
            if (evalValues == null)
            {
                return ErrorToResults(ArticleDecorateMessage(EXCEPTION_VALUES_NULL_TEXT));
            }
            if (evalProfile == null)
            {
                return ErrorToResults(ArticleDecorateMessage(EXCEPTION_EXPERT_NULL_TEXT));
            }
            return InternalEvaluate(evalTarget, InternalCode, evalValues, evalPeriod, evalProfile, evalResults);
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
