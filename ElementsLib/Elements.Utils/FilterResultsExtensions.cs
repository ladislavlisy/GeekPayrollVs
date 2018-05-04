using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Utils
{
    using ConfigCode = UInt16;
    using ConfigBase = Module.Interfaces.Matrixus.IArticleConfigFeatures;

    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using TargetSeed = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValuesItem = Module.Interfaces.Elements.IArticleResultValues;

    using Module.Libs;
    using ResultMonad;
    using MaybeMonad;
    using Module.Interfaces.Elements;

    public static class FilterResultsExtensions
    {
        public static string ERROR_TEXT_CONTRACT_NOT_FOUND = "Contract Result not found!";
        public static string ERROR_TEXT_POSITION_NOT_FOUND = "Position Result not found!";
        public static string ERROR_TEXT_CONTRACT_CODE_NOT_FOUND = "Result for Contract Target and Code not found!";
        public static string ERROR_TEXT_POSITION_CODE_NOT_FOUND = "Result for Position Target and Code not found!";
        public static string ERROR_TEXT_RESULTS_CASTING_FAILED = "Failed casting";
        public static string ERROR_TEXT_RESULTS_LOOKUP_FAILED = "Failed value lookup";
        public static string ERROR_TEXT_RESULTS_SELECT_FAILED = "Failed value select";
        public static ResultPack FindContractResultForCode(this IEnumerable<ResultPair> evalResults, ConfigCode contractCode, TargetSeed contractSeed)
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusSeed(contractCode, contractSeed));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);

            return findResult;
        }

        public static Result<TResult, string> FindContractTypeResultForCode<TResult>(this IEnumerable<ResultPair> evalResults, ConfigCode contractCode, TargetSeed contractSeed) where TResult : class, ResultItem
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusSeed(contractCode, contractSeed));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TResult, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TResult, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            return Result.Ok<TResult, string>(typeResult);
        }
        public static Result<TRValue, string> FindContractResultValueForCode<TResult, TRValue>(this IEnumerable<ResultPair> evalResults, 
            ConfigCode contractCode, TargetSeed contractSeed, 
            Func<ValuesItem, bool> getValsFunc) 
            where TResult : class, ResultItem
            where TRValue : class, ValuesItem
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusSeed(contractCode, contractSeed));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TRValue, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            Maybe<TRValue> typeValues = typeResult.ReturnValue<TRValue>(getValsFunc);
            if (typeValues.HasNoValue)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_LOOKUP_FAILED);
            }
            return Result.Ok<TRValue, string>(typeValues.Value);
        }

        public static ResultPack FindPositionResultForCode(this IEnumerable<ResultPair> evalResults, ConfigCode positionCode, TargetHead contractCode, TargetSeed positionSeed)
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndSeed(positionCode, contractCode, positionSeed));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_POSITION_NOT_FOUND);

            return findResult;
        }

        public static Result<TResult, string> FindPositionTypeResultForCode<TResult>(this IEnumerable<ResultPair> evalResults, ConfigCode positionCode, TargetHead contractCode, TargetSeed positionSeed) where TResult : class, ResultItem
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndSeed(positionCode, contractCode, positionSeed));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TResult, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TResult, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            return Result.Ok<TResult, string>(typeResult);
        }
        public static Result<TRValue, string> FindPositionResultValueForCode<TResult, TRValue>(this IEnumerable<ResultPair> evalResults, ConfigCode positionCode, TargetHead contractCode, TargetSeed positionSeed, 
            Func<ValuesItem, bool> getValsFunc) 
            where TResult : class, ResultItem
            where TRValue : class, ValuesItem
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndSeed(positionCode, contractCode, positionSeed));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TRValue, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            Maybe<TRValue> typeValues = typeResult.ReturnValue<TRValue>(getValsFunc);
            if (typeValues.HasNoValue)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_LOOKUP_FAILED);
            }
            return Result.Ok<TRValue, string>(typeValues.Value);
        }

        public static ResultPack FindResultForCodePlusHead(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode)
        {
            TargetPart partCode = ArticleTarget.PART_CODE_NULL;

            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_CODE_NOT_FOUND);

            return findResult;
        }
        public static Result<TResult, string> FindTypeResultForCodePlusHead<TResult>(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode) where TResult : class, ResultItem
        {
            TargetPart partCode = ArticleTarget.PART_CODE_NULL;

            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TResult, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TResult, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            return Result.Ok<TResult, string>(typeResult);
        }
        public static Result<TRValue, string> FindResultValueForCodePlusHead<TResult, TRValue>(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode,
            Func<ValuesItem, bool> getValsFunc)
            where TResult : class, ResultItem
            where TRValue : class, ValuesItem
        {
            TargetPart partCode = ArticleTarget.PART_CODE_NULL;

            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TRValue, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            Maybe<TRValue> typeValues = typeResult.ReturnValue<TRValue>(getValsFunc);
            if (typeValues.HasNoValue)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_LOOKUP_FAILED);
            }
            return Result.Ok<TRValue, string>(typeValues.Value);
        }


        public static ResultPack FindResultForCodePlusPart(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode, TargetPart partCode)
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_POSITION_CODE_NOT_FOUND);

            return findResult;
        }
        public static Result<TResult, string> FindTypeResultForCodePlusPart<TResult>(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode, TargetPart partCode) where TResult : class, ResultItem
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TResult, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TResult, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            return Result.Ok<TResult, string>(typeResult);
        }
        public static Result<TRValue, string> FindResultValueForCodePlusPart<TResult, TRValue>(this IEnumerable<ResultPair> evalResults, ConfigCode findCode, TargetHead headCode, TargetPart partCode,
            Func<ValuesItem, bool> getValsFunc)
            where TResult : class, ResultItem
            where TRValue : class, ValuesItem
        {
            Func<TargetItem, bool> filterFunc = (x) => (x.IsEqualByCodePlusHeadAndPart(findCode, headCode, partCode));

            ResultPack findResult = evalResults.FirstToResultWithValueAndError(filterFunc, ERROR_TEXT_CONTRACT_NOT_FOUND);
            if (findResult.IsFailure)
            {
                return Result.Fail<TRValue, string>(findResult.Error);
            }
            TResult typeResult = findResult.Value as TResult;
            if (typeResult == null)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
            }
            Maybe<TRValue> typeValues = typeResult.ReturnValue<TRValue>(getValsFunc);
            if (typeValues.HasNoValue)
            {
                return Result.Fail<TRValue, string>(ERROR_TEXT_RESULTS_LOOKUP_FAILED);
            }
            return Result.Ok<TRValue, string>(typeValues.Value);
        }

        public static Result<IEnumerable<ResultPair>, string> GetTypedResultsInListAndError<TResult>(this IEnumerable<ResultPair> evalResults,
            Func<TargetItem, bool> filterTargetFunc) where TResult : class, ResultItem
        {
            Func<Result<IEnumerable<ResultPair>, string>, ResultPair,
                Func<TargetItem, bool>, Result<IEnumerable<ResultPair>, string>> agrFunc = (bAgr, a, tFilter) => {
                    if (bAgr.IsFailure)
                    {
                        return Result.Fail<IEnumerable<ResultPair>, string>(bAgr.Error);
                    }
                    IEnumerable<ResultPair> bAgrList = bAgr.Value;
                    Result<ResultItem, string> aResult = a.Value;
                    if (aResult.IsFailure)
                    {
                        return Result.Fail<IEnumerable<ResultPair>, string>(aResult.Error);
                    }
                    TargetItem aParamKey = a.Key;
                    if (tFilter(aParamKey) == false)
                    {
                        return Result.Ok<IEnumerable<ResultPair>, string>(bAgrList);
                    }
                    TResult typeResult = aResult.Value as TResult;
                    if (typeResult == null)
                    {
                        return Result.Fail<IEnumerable<ResultPair>, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
                    }
                    IEnumerable<ResultPair> resultList = bAgrList.Merge(a).OrderBy((x) => (x.Key));

                    return Result.Ok<IEnumerable<ResultPair>, string>(resultList);
                };

            Result<IEnumerable<ResultPair>, string> initResult = Result.Ok<IEnumerable<ResultPair>, string>(new List<ResultPair>());
            return evalResults.Aggregate(initResult, (agr, x) => agrFunc(agr, x, filterTargetFunc));
        }
        public static Result<IEnumerable<TRValue>, string> GetResultValuesInListAndError<TResult, TRValue>(this IEnumerable<ResultPair> evalResults,
            Func<TargetItem, bool> filterTargetFunc, Func<TResult, bool> filterValuesFunc,
            Func<ValuesItem, bool> selectValuesFunc)
            where TResult : class, ResultItem
            where TRValue : class, ValuesItem
        {
            Func<Result<IEnumerable<TRValue>, string>, ResultPair,
                Func<TargetItem, bool>, Func<TResult, bool>, Func<ValuesItem, bool>,
                Result<IEnumerable<TRValue>, string>> agrFunc = (bAgr, a, tFilter, vFilter, exfunc) => {
                    if (bAgr.IsFailure)
                    {
                        return Result.Fail<IEnumerable<TRValue>, string>(bAgr.Error);
                    }
                    IEnumerable<TRValue> bAgrList = bAgr.Value;
                    Result<ResultItem, string> aResult = a.Value;
                    if (aResult.IsFailure)
                    {
                        return Result.Fail<IEnumerable<TRValue>, string>(aResult.Error);
                    }
                    TargetItem aParamKey = a.Key;
                    if (tFilter(aParamKey) == false)
                    {
                        return Result.Ok<IEnumerable<TRValue>, string>(bAgrList);
                    }
                    TResult aParamVal = aResult.Value as TResult;
                    if (aParamVal == null)
                    {
                        return Result.Fail<IEnumerable<TRValue>, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
                    }
                    if (vFilter(aParamVal) == false)
                    {
                        return Result.Ok<IEnumerable<TRValue>, string>(bAgrList);
                    }
                    Maybe<TRValue> typeValues = aParamVal.ReturnValue<TRValue>(exfunc);
                    if (typeValues.HasNoValue)
                    {
                        return Result.Fail<IEnumerable<TRValue>, string>(ERROR_TEXT_RESULTS_LOOKUP_FAILED);
                    }
                    IEnumerable<TRValue> resultList = bAgrList.Merge(typeValues.Value);

                    return Result.Ok<IEnumerable<TRValue>, string>(resultList);
                };

            Result<IEnumerable<TRValue>, string> initResult = Result.Ok<IEnumerable<TRValue>, string>(new List<TRValue>());
            return evalResults.Aggregate(initResult, (agr, x) => agrFunc(agr, x, filterTargetFunc, filterValuesFunc, selectValuesFunc));
        }
        public static Result<IEnumerable<TSValue>, string> GetResultValuesInListAndError<TResult, TRValue, TSValue>(this IEnumerable<ResultPair> evalResults,
            Func<TargetItem, bool> filterTargetFunc, Func<TResult, bool> filterValuesFunc,
            Func<ValuesItem, bool> selectValuesFunc, Func<TargetItem, TRValue, Result<TSValue, string>> selectResultFunc)
            where TResult : class, ResultItem
            where TRValue : class, ValuesItem
        {
            Func<Result<IEnumerable<TSValue>, string>, ResultPair,
                Func<TargetItem, bool>, Func<TResult, bool>, Func<ValuesItem, bool>, Func<TargetItem, TRValue, Result<TSValue, string>>,
                Result<IEnumerable<TSValue>, string>> agrFunc = (bAgr, a, tFilter, vFilter, vSelect, rSelect) => {
                    if (bAgr.IsFailure)
                    {
                        return Result.Fail<IEnumerable<TSValue>, string>(bAgr.Error);
                    }
                    IEnumerable<TSValue> bAgrList = bAgr.Value;
                    Result<ResultItem, string> aResult = a.Value;
                    if (aResult.IsFailure)
                    {
                        return Result.Fail<IEnumerable<TSValue>, string>(aResult.Error);
                    }
                    TargetItem aParamKey = a.Key;
                    if (tFilter(aParamKey) == false)
                    {
                        return Result.Ok<IEnumerable<TSValue>, string>(bAgrList);
                    }
                    TResult aParamVal = aResult.Value as TResult;
                    if (aParamVal == null)
                    {
                        return Result.Fail<IEnumerable<TSValue>, string>(ERROR_TEXT_RESULTS_CASTING_FAILED);
                    }
                    if (vFilter(aParamVal) == false)
                    {
                        return Result.Ok<IEnumerable<TSValue>, string>(bAgrList);
                    }
                    Maybe<TRValue> typeValues = aParamVal.ReturnValue<TRValue>(vSelect);
                    if (typeValues.HasNoValue)
                    {
                        return Result.Fail<IEnumerable<TSValue>, string>(ERROR_TEXT_RESULTS_LOOKUP_FAILED);
                    }
                    Result<TSValue, string> selResult = rSelect(aParamKey, typeValues.Value);
                    if (selResult.IsFailure)
                    {
                        return Result.Fail<IEnumerable<TSValue>, string>(ERROR_TEXT_RESULTS_SELECT_FAILED);
                    }

                    IEnumerable<TSValue> resultList = bAgrList.Merge(selResult.Value);

                    return Result.Ok<IEnumerable<TSValue>, string>(resultList);
                };

            Result<IEnumerable<TSValue>, string> initResult = Result.Ok<IEnumerable<TSValue>, string>(new List<TSValue>());
            return evalResults.Aggregate(initResult, (agr, x) => agrFunc(agr, x, filterTargetFunc, filterValuesFunc, selectValuesFunc, selectResultFunc));
        }
    }
}
