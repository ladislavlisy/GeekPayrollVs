using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config.Concepts
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;
    using MasterItem = Articles.TaxIncomesGeneralArticle;

    using TAmount = Decimal;

    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Utils;
    using Sources;
    using Results;
    using ResultMonad;
    using Legalist.Constants;

    public static class TaxIncomesGeneralConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "TaxIncomesGeneralConcept(ARTICLE_TAX_INCOMES_GENERAL, 1004): {0}";
        public static string CONCEPT_PROFILE_NULL_TEXT = "Taxing profile is null!";

        public static IEnumerable<ResultPack> EvaluateConcept(ConfigCode evalCode, Period evalPeriod, IPeriodProfile evalProfile,
            Result<MasterItem.EvaluateSource, string> prepValues)
        {
            ITaxingProfile conceptProfile = evalProfile.Taxing();
            if (conceptProfile == null)
            {
                return EvaluateUtils.DecoratedError(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);
            }

            MasterItem.EvaluateSource conceptValues = prepValues.Value;
            // EVALUATION
            TAmount incomeEmployRelated = conceptProfile.TaxableGeneralIncomes(evalPeriod, conceptValues.SummarizeType);
            TAmount incomeAgWorkRelated = conceptProfile.TaxableAggWorkIncomes(evalPeriod, conceptValues.SummarizeType);
            TAmount incomeStatutRelated = conceptProfile.TaxableStatutsIncomes(evalPeriod, conceptValues.SummarizeType);
            TAmount incomeTotalsExclude = conceptProfile.ExcludeGeneralIncomes(evalPeriod, conceptValues.SummarizeType);
            // EVALUATION

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode);
            // SET RESULT VALUES
            conceptResult.AddIncomeTaxGeneralValue(conceptValues.SummarizeType, incomeEmployRelated, incomeTotalsExclude);
            // SET RESULT VALUES

            return EvaluateUtils.Results(conceptResult);
        }
    }
}
