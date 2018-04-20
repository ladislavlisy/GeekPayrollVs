using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;

    using Module.Codes;
    using Module.Interfaces.Elements;
    using Module.Libs;
    using Module.Items;
    using Module.Interfaces.Legalist;
    using System.Linq;

    public abstract class GeneralArticle : IArticleSource, ICloneable
    {
        protected delegate IEnumerable<ResultPack> EvaluateDelegate(TargetItem evalTarget, ConfigCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults);

        public static string EXCEPTION_RESULT_NONE_TEXT = "Evaluate Results is not implemented!";
        public static string EXCEPTION_VALUES_NULL_TEXT = "Source values are null!";
        public static string EXCEPTION_EXPERT_NULL_TEXT = "Expert profile is null!";
        public static string EXCEPTION_PERIOD_NULL_TEXT = "Period is null!";
        public static string EXCEPTION_TARGET_NULL_TEXT = "Target is null!";
        public static string EXCEPTION_RESULT_NULL_TEXT = "List of Results is null!";

public abstract string ArticleDecorateMessage(string message);
        public abstract void ImportSourceValues(ISourceValues values);
        public abstract ISourceValues ExportSourceValues();
        public GeneralArticle(ConfigRole role)
        {
            InternalCode = 0;

            InternalRole = role;

            InternalEvaluate = null;
        }

        protected ConfigCode InternalCode { get; set; }
        protected ConfigRole InternalRole { get; set; }

        protected EvaluateDelegate InternalEvaluate;
        public ConfigCode Code()
        {
            return InternalCode;
        }
        public ConfigCode Role()
        {
            return InternalRole;
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

        protected ValidsPack ValidationError(string errorText)
        {
            return Result.Fail<bool, string>(errorText);
        }
        protected ValidsPack ValidationOk()
        {
            return Result.Ok<bool, string>(true);
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

        public virtual IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            ValidsPack validParams = ValidateParams(evalTarget, evalPeriod, evalProfile, evalResults);
            if (validParams.IsFailure)
            {
                return ErrorToResults(ArticleDecorateMessage(validParams.Error));
            }
            if (InternalEvaluate == null)
            {
                return ErrorToResults(ArticleDecorateMessage(EXCEPTION_RESULT_NONE_TEXT));
            }
            ISourceValues evalValues = ExportSourceValues();
            if (evalValues == null)
            {
                return ErrorToResults(ArticleDecorateMessage(EXCEPTION_VALUES_NULL_TEXT));
            }
            return InternalEvaluate(evalTarget, InternalCode, evalValues, evalPeriod, evalProfile, evalResults);
        }

        protected ValidsPack ValidateParams(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            if (evalProfile == null)
            {
                return ValidationError(EXCEPTION_EXPERT_NULL_TEXT);
            }
            if (evalPeriod == null)
            {
                return ValidationError(EXCEPTION_PERIOD_NULL_TEXT);
            }
            if (evalTarget == null)
            {
                return ValidationError(EXCEPTION_TARGET_NULL_TEXT);
            }
            if (evalResults == null)
            {
                return ValidationError(EXCEPTION_RESULT_NULL_TEXT);
            }
            return ValidationOk();
        }

        public virtual object Clone()
        {
            GeneralArticle cloneArticle = (GeneralArticle)this.MemberwiseClone();
            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalEvaluate = this.InternalEvaluate;

            return cloneArticle;
        }
        public override string ToString()
        {
            return ArticleRoleAdapter.GetSymbol(InternalRole);
        }

    }
}
