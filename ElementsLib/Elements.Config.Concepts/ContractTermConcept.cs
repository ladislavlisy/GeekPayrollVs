using System;
using System.Collections.Generic;

namespace ElementsLib.Elements.Config.Concepts
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;

    using TDay = Byte;

    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Utils;
    using Sources;
    using Results;

    public class ContractTermConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "ContractTermConcept(ARTICLE_CONTRACT_TERM, 1): {0}";

        public static string CONCEPT_PROFILE_NULL_TEXT = "Employ profile is null!";
        public static string CONCEPT_VALUES_INVALID_TEXT = "Invalid source values!";
        public static string CONCEPT_RESULT_NONE_TEXT = "Evaluate Results is not implemented!";
        public static IEnumerable<ResultPack> EvaluateConcept(TargetItem evalTarget, ConfigCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            IEmployProfile conceptProfile = evalProfile.Employ();
            if (conceptProfile == null)
            {
                return ConceptDecorateResultError(CONCEPT_PROFILE_NULL_TEXT);
            }
            ContractTermSource conceptValues = evalValues as ContractTermSource;
            if (conceptValues == null)
            {
                return ConceptDecorateResultError(CONCEPT_VALUES_INVALID_TEXT);
            }
            TDay dayTermFrom = conceptProfile.DateFromInPeriod(evalPeriod, conceptValues.DateFrom);
            TDay dayTermStop = conceptProfile.DateStopInPeriod(evalPeriod, conceptValues.DateStop);

            IArticleResult conceptResult = new ArticleGeneralResult(evalCode, dayTermFrom, dayTermStop);

            return EvaluateUtils.Results(conceptResult);
        }
        public static IEnumerable<ResultPack> ConceptDecorateResultError(string message)
        {
            string conceptMessage = string.Format(CONCEPT_DESCRIPTION_ERROR_FORMAT, message);

            return EvaluateUtils.Error(conceptMessage);
        }
    }
}
