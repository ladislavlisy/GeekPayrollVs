using System;
using System.Collections.Generic;

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

    public static class ResultMonadListExtensions
    {
        public static Result<IEnumerable<KValue>, TError> ToResultWithValueListAndError<TValue, TError, KValue>(
            this IEnumerable<Result<TValue, TError>> results,
            Func<TValue, Result<KValue, TError>> onSuccessFunc)
        {
            IEnumerable<KValue> resultList = new List<KValue>();
            foreach (var r in results)
            {
                if (r.IsFailure)
                {
                    return Result.Fail<IEnumerable<KValue>, TError>(r.Error);
                }
                Result<KValue, TError> v = onSuccessFunc(r.Value);
                if (v.IsFailure)
                {
                    return Result.Fail<IEnumerable<KValue>, TError>(v.Error);
                }
                resultList = resultList.Merge(v.Value);
            }
            return Result.Ok<IEnumerable<KValue>, TError>(resultList);
        }

        public static Result<IEnumerable<KValue>, TError> ToResultWithValueListAndError<Target, TValue, TError, KValue>(
            this IEnumerable<KeyValuePair<Target, Result<TValue, TError>>> results,
            Func<KeyValuePair<Target, Result<TValue, TError>>, Result<KValue, TError>> onSuccessFunc)
        {
            IEnumerable<KValue> resultList = new List<KValue>();
            foreach (var kv in results)
            {
                Result<TValue, TError> r = kv.Value;
                if (r.IsFailure)
                {
                    return Result.Fail<IEnumerable<KValue>, TError>(r.Error);
                }
                Result<KValue, TError> v = onSuccessFunc(kv);
                if (v.IsFailure)
                {
                    return Result.Fail<IEnumerable<KValue>, TError>(v.Error);
                }
                resultList = resultList.Merge(v.Value);
            }
            return Result.Ok<IEnumerable<KValue>, TError>(resultList);
        }

    }
}
