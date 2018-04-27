using System;
using MaybeMonad;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Module.Items.Utils
{
    public static class MaybeMonadUtils
    {
        public static bool HaveAllNotNullValues<TValue>(params TValue[] results) where TValue : class
        {
            return results.Aggregate(true, (agr, x) => (agr && x != null));
        }
        public static bool HaveResultsValues<TValue>(params Maybe<TValue>[] results)
        {
            return results.Aggregate(true, (agr, x) => (agr && x.HasValue));
        }
        public static bool HaveAllResultsValues<AValue, BValue>(Maybe<AValue> resultA, Maybe<BValue> resultB)
        {
            return (resultA.HasValue && resultB.HasValue);
        }
        public static bool HaveAllResultsValues<AValue, BValue, CValue>(Maybe<AValue> resultA, Maybe<BValue> resultB, Maybe<CValue> resultC)
        {
            return (resultA.HasValue && resultB.HasValue && resultC.HasValue);
        }
    }
}
