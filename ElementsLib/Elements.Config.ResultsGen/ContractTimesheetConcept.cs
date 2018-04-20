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

    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Utils;
    using Sources;
    using Results;

    public static class ContractTimesheetConcept
    {
        public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = "ContractTimesheetConcept(ARTICLE_CONTRACT_TIMESHEET, 7): {0}";
        public static string CONCEPT_RESULT_NONE_TEXT = "Evaluate Results is not implemented!";

        public static IEnumerable<ResultPack> EvaluateConcept(TargetItem evalTarget, ConfigCode evalCode, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            return ConceptDecorateResultError(CONCEPT_RESULT_NONE_TEXT);
        }

        public static IEnumerable<ResultPack> ConceptDecorateResultError(string message)
        {
            string conceptMessage = string.Format(CONCEPT_DESCRIPTION_ERROR_FORMAT, message);

            return EvaluateUtils.Error(conceptMessage);
        }
    }
}
