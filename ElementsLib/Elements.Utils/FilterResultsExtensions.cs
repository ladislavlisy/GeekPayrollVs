using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Utils
{
    using ConfigCode = UInt16;

    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using TargetSeed = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;

    using Module.Interfaces.Elements;
    using ResultMonad;

    public static class FilterResultsExtensions
    {
        public static ResultPack FindResultForCodePlusSeed(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetSeed findSeed)
        {
            ResultPair findResult = evalResults.FirstOrDefault((r) => IsEqualByCodePlusSeed(r.Key, findCode, findSeed));

            if (findResult.Key == null)
            {
                return ResultsUtils.Error("Result for Target and Code not found!");
            }
            ResultPack packResult = findResult.Value;
            if (packResult.IsFailure)
            {
                return ResultsUtils.Error(packResult.Error);
            }
            return packResult;
        }

        public static bool IsEqualByCodePlusSeed(IArticleTarget currtarget, ConfigCode findCode, TargetSeed findSeed)
        {
            return currtarget.IsEqualByCodePlusSeed(findCode, findSeed);
        }
    }
}
