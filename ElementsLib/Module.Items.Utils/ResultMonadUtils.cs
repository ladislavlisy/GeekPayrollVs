using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Module.Items.Utils
{
    using Libs;
    using ResultMonad;

    public static class ResultMonadUtils
    {
        public static Result<IEnumerable<Tuple<TAValue, TBValue>>, TError> ZipToResultWithTupleListAndError<TAValue, TBValue, TError>(
            IEnumerable<TAValue> resultsA, IEnumerable<TBValue> resultsB,
            TError errorOnResultA, TError errorOnResultB, Func<TAValue, TBValue, int> compareFunc)
        {
            IEnumerable<Tuple<TAValue, TBValue>> resultList = new List<Tuple<TAValue, TBValue>>();

            var enumA = resultsA.GetEnumerator();
            var enumB = resultsB.GetEnumerator();

            Result<TAValue, TError> resultItemA = Result.Fail<TAValue, TError>(errorOnResultA);
            bool bIsCurrentA = enumA.MoveNext();
            Result<TBValue, TError> resultItemB = Result.Fail<TBValue, TError>(errorOnResultB);
            bool bIsCurrentB = enumB.MoveNext();
            while (bIsCurrentA || bIsCurrentB)
            {
                resultItemA = Result.Fail<TAValue, TError>(errorOnResultA);
                if (bIsCurrentA)
                {
                    resultItemA = Result.Ok<TAValue, TError>(enumA.Current);
                }
                resultItemB = Result.Fail<TBValue, TError>(errorOnResultB);
                if (bIsCurrentB)
                {
                    resultItemB = Result.Ok<TBValue, TError>(enumB.Current);
                }
                if (resultItemA.IsFailure)
                {
                    return Result.Fail<IEnumerable<Tuple<TAValue, TBValue>>, TError>(resultItemA.Error);
                }
                if (resultItemB.IsFailure)
                {
                    return Result.Fail<IEnumerable<Tuple<TAValue, TBValue>>, TError>(resultItemB.Error);
                }
                int compareResults = compareFunc(resultItemA.Value, resultItemB.Value);
                if (compareResults > 0)
                {
                    bIsCurrentB = enumB.MoveNext();
                }
                else if (compareResults < 0)
                {
                    bIsCurrentA = enumA.MoveNext();
                }
                else
                {
                    resultList = resultList.Merge(new Tuple<TAValue, TBValue>(resultItemA.Value, resultItemB.Value));

                    bIsCurrentA = enumA.MoveNext();
                    bIsCurrentB = enumB.MoveNext();
                }
            }
            return Result.Ok<IEnumerable<Tuple<TAValue, TBValue>>, TError>(resultList);
        }
        public static Result<IEnumerable<KeyValuePair<TIndex, Tuple<TAValue, TBValue>>>, TError> ZipToResultWithTupleListAndError<TIndex, Target, TAValue, TBValue, TError>(
            IEnumerable<KeyValuePair<Target, Result<TAValue, TError>>> resultsA, IEnumerable<KeyValuePair<Target, Result<TBValue, TError>>> resultsB,
            TError errorOnResultA, TError errorOnResultB, 
            Func<Target, Target, TIndex> keyIndexFunc, Func<KeyValuePair<Target, Result<TAValue, TError>>, KeyValuePair<Target, Result<TBValue, TError>>, int> compareFunc)
        {
            IEnumerable<KeyValuePair<TIndex, Tuple<TAValue, TBValue>>> resultList = new List<KeyValuePair<TIndex, Tuple<TAValue, TBValue>>>();

            var enumA = resultsA.GetEnumerator();
            var enumB = resultsB.GetEnumerator();

            KeyValuePair<Target, Result<TAValue, TError>> resultItemA = new KeyValuePair<Target, Result<TAValue, TError>>(default(Target), Result.Fail<TAValue, TError>(errorOnResultA));
            bool bIsCurrentA = enumA.MoveNext();
            KeyValuePair<Target, Result<TBValue, TError>> resultItemB = new KeyValuePair<Target, Result<TBValue, TError>>(default(Target), Result.Fail<TBValue, TError>(errorOnResultB));
            bool bIsCurrentB = enumB.MoveNext();
            while (bIsCurrentA || bIsCurrentB)
            {
                resultItemA = new KeyValuePair<Target, Result<TAValue, TError>>(default(Target), Result.Fail<TAValue, TError>(errorOnResultA));
                if (bIsCurrentA)
                {
                    resultItemA = enumA.Current;
                }
                resultItemB = new KeyValuePair<Target, Result<TBValue, TError>>(default(Target), Result.Fail<TBValue, TError>(errorOnResultB));
                if (bIsCurrentB)
                {
                    resultItemB = enumB.Current;
                }
                if (resultItemA.Value.IsFailure)
                {
                    return Result.Fail<IEnumerable<KeyValuePair<TIndex, Tuple<TAValue, TBValue>>>, TError>(resultItemA.Value.Error);
                }
                if (resultItemB.Value.IsFailure)
                {
                    return Result.Fail<IEnumerable<KeyValuePair<TIndex, Tuple<TAValue, TBValue>>>, TError>(resultItemB.Value.Error);
                }
                int compareResults = compareFunc(resultItemA, resultItemB);
                if (compareResults > 0)
                {
                    bIsCurrentB = enumB.MoveNext();
                }
                else if (compareResults < 0)
                {
                    bIsCurrentA = enumA.MoveNext();
                }
                else
                {
                    Result<TAValue, TError> resultValueA = resultItemA.Value;
                    Result<TBValue, TError> resultValueB = resultItemB.Value;
                    TIndex resultKey = keyIndexFunc(resultItemA.Key, resultItemB.Key);
                    resultList = resultList.Merge(new KeyValuePair<TIndex, Tuple<TAValue, TBValue>>(resultKey, new Tuple<TAValue, TBValue>(resultValueA.Value, resultValueB.Value)));

                    bIsCurrentA = enumA.MoveNext();
                    bIsCurrentB = enumB.MoveNext();
                }
            }
            return Result.Ok<IEnumerable<KeyValuePair<TIndex, Tuple<TAValue, TBValue>>>, TError>(resultList);
        }
    }
}
