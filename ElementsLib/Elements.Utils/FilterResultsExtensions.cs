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
        public static ResultPack FindContractResultForCode(this IEnumerable<ResultPair> evalResults, ConfigCode contractCode, TargetSeed contractSeed)
        {
            ResultPair findResult = evalResults.FirstOrDefault((r) => IsEqualByCodePlusSeed(r.Key, contractCode, contractSeed));

            if (findResult.Key == null)
            {
                return ResultsUtils.Error("Contract Result not found!");
            }
            ResultPack packResult = findResult.Value;
            if (packResult.IsFailure)
            {
                return ResultsUtils.Error(packResult.Error);
            }
            return packResult;
        }

        public static ResultPack FindPositionResultForCode(this IEnumerable<ResultPair> evalResults, ConfigCode positionCode, TargetHead contractCode, TargetSeed positionSeed)
        {
            ResultPair findResult = evalResults.FirstOrDefault((r) => IsEqualByCodePlusHeadAndSeed(r.Key, positionCode, contractCode, positionSeed));

            if (findResult.Key == null)
            {
                return ResultsUtils.Error("Position Result not found!");
            }
            ResultPack packResult = findResult.Value;
            if (packResult.IsFailure)
            {
                return ResultsUtils.Error(packResult.Error);
            }
            return packResult;
        }

        public static ResultPack FindResultForCodePlusHead(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode)
        {
            TargetPart partCode = ArticleTarget.PART_CODE_NULL;

            ResultPair findResult = evalResults.FirstOrDefault((r) => IsEqualByCodePlusHeadAndPart(r.Key, findCode, headCode, partCode));

            if (findResult.Key == null)
            {
                return ResultsUtils.Error("Result for Contract Target and Code not found!");
            }
            ResultPack packResult = findResult.Value;
            if (packResult.IsFailure)
            {
                return ResultsUtils.Error(packResult.Error);
            }
            return packResult;
        }

        public static ResultPack FindResultForCodePlusPart(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode, TargetPart partCode)
        {
            ResultPair findResult = evalResults.FirstOrDefault((r) => IsEqualByCodePlusHeadAndPart(r.Key, findCode, headCode, partCode));

            if (findResult.Key == null)
            {
                return ResultsUtils.Error("Result for Position Target and Code not found!");
            }
            ResultPack packResult = findResult.Value;
            if (packResult.IsFailure)
            {
                return ResultsUtils.Error(packResult.Error);
            }
            return packResult;
        }

        public static IEnumerable<ResultPack> GetResultForCodePlusHead(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode)
        {
            IEnumerable<ResultPair> findResults = evalResults.Where((r) => IsEqualByCodePlusHead(r.Key, findCode, headCode));

            IEnumerable<ResultPack> packResults = findResults.Select((r) => (r.Value));

            return packResults;
        }

        public static bool IsEqualByCodePlusSeed(IArticleTarget currtarget, ConfigCode findCode, TargetSeed findSeed)
        {
            return currtarget.IsEqualByCodePlusSeed(findCode, findSeed);
        }
        public static bool IsEqualByCodePlusHead(IArticleTarget currtarget, ConfigCode findCode, TargetHead headCode)
        {
            return currtarget.IsEqualByCodePlusHead(findCode, headCode);
        }
        public static bool IsEqualByCodePlusHeadAndSeed(IArticleTarget currtarget, ConfigCode findCode, TargetHead headCode, TargetSeed findSeed)
        {
            return currtarget.IsEqualByCodePlusHeadAndSeed(findCode, headCode, findSeed);
        }
        public static bool IsEqualByCodePlusHeadAndPart(IArticleTarget currtarget, ConfigCode findCode, TargetHead headCode, TargetPart partCode)
        {
            return currtarget.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode);
        }
    }
}
