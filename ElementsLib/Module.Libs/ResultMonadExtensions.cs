using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Libs
{
    using ErrorsItem = String;
    using TargetItem = Interfaces.Elements.IArticleTarget;
    using SourceItem = Interfaces.Elements.IArticleSource;
    using SourcePack = ResultMonad.Result<Interfaces.Elements.IArticleSource, string>;
    using SourcePair = KeyValuePair<Interfaces.Elements.IArticleTarget, ResultMonad.Result<Interfaces.Elements.IArticleSource, string>>;
    using ResultItem = Interfaces.Elements.IArticleResult;
    using ResultPack = ResultMonad.Result<Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Interfaces.Elements.IArticleTarget, ResultMonad.Result<Interfaces.Elements.IArticleResult, string>>;
    using ResultMonad;
    using Items;
    using Interfaces.Legalist;

    public static class ResultMonadExtensions
    {
        public static string Description(this SourcePack value)
        {
            if (value.IsFailure)
            {
                return string.Format("Error: {0}", value.Error.ToString());
            }
            else
            {
                return value.Value.ToString();
            }
        }
        public static string Description(this ResultPack value)
        {
            if (value.IsFailure)
            {
                return string.Format("Error: {0}", value.Error.ToString());
            }
            else
            {
                return value.Value.ToString();
            }
        }
        public static IEnumerable<ResultPack> OnSuccessToResultSet(
            this SourcePack result, Func<SourceItem, IEnumerable<ResultPack>> onSuccessFunc)
        {
            if (result.IsFailure)
            {
                return new List<ResultPack>() { Result.Fail<ResultItem, ErrorsItem>(result.Error) };
            }

            return onSuccessFunc(result.Value);
        }
        public static IEnumerable<ResultPack> OnSuccessEvaluateToResultSet(
            this SourcePack result, TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults, 
            Func<SourceItem, TargetItem, Period, IPeriodProfile, IEnumerable<ResultPack>, IEnumerable<ResultPack>> onSuccessFunc)
        {
            if (result.IsFailure)
            {
                return new List<ResultPack>() { Result.Fail<ResultItem, ErrorsItem>(result.Error) };
            }

            return onSuccessFunc(result.Value, evalTarget, evalPeriod, evalProfile, evalResults);
        }
        public static IEnumerable<ResultPack> ToList(this ResultPack result)
        {
            return new List<ResultPack>() { result };
        }
    }
    public static class ResultMonadKeyValueExtensions
    {
        public static string Description(this SourcePair value)
        {
            TargetItem node = value.Key;

            SourcePack item = value.Value;

            return string.Format("{0} {1}", node.ToString(), item.Description());
        }

        public static string Description(this ResultPair value)
        {
            TargetItem node = value.Key;

            ResultPack item = value.Value;

            return string.Format("{0} {1}", node.ToString(), item.Description());
        }


    }
}
