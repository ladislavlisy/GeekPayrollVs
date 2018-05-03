﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config.Concepts
{
    using ConfigCode = UInt16;
    using ConfigBase = Module.Interfaces.Matrixus.IArticleConfigFeatures;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;
    using MasterItem = Articles.ContractTermArticle;

    using TDay = Byte;

    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Utils;
    using Sources;
    using Results;
    using ResultMonad;

    public static class ContractTermConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "ContractTermConcept(ARTICLE_CONTRACT_TERM, 1): {0}";
        public static string CONCEPT_PROFILE_NULL_TEXT = "Employ profile is null!";

        public static IEnumerable<ResultPack> EvaluateConcept(ConfigBase evalConfig, Period evalPeriod, IPeriodProfile evalProfile,
            Result<MasterItem.EvaluateSource, string> prepValues)
        {
            IEmployProfile conceptProfile = evalProfile.Employ();
            if (conceptProfile == null)
            {
                return EvaluateUtils.DecoratedError(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);
            }

            MasterItem.EvaluateSource conceptValues = prepValues.Value;
            // EVALUATION
            TDay dayTermFrom = conceptProfile.DateFromInPeriod(evalPeriod, conceptValues.DateTermFrom);
            TDay dayTermStop = conceptProfile.DateStopInPeriod(evalPeriod, conceptValues.DateTermStop);
            // EVALUATION

            IArticleResult conceptResult = new ArticleGeneralResult(evalConfig);

            // SET RESULT VALUES
            conceptResult.AddContractFromStop(conceptValues.DateTermFrom, conceptValues.DateTermStop, conceptValues.ContractType);
            conceptResult.AddMonthFromStop(dayTermFrom, dayTermStop);
            // SET RESULT VALUES

            return EvaluateUtils.Results(conceptResult);
        }
    }
}
