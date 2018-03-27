using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using ExtendedCode = UInt16;
    using ExtendedSeed = UInt16;

    public static class TargetSelector
    {
        static public ExtendedSeed GetFirstTargetSeed(IEnumerable<ArticleTarget> targetList, ContractCode contract, PositionCode position, ExtendedCode code)
        {
            IEnumerable<ArticleTarget> selectedTargets = SelectEquals(targetList, contract, position, code);

            IEnumerable<ExtendedSeed> oneCodeSeeds = ExtractCodeSeed(selectedTargets);

            return FirstSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static public ExtendedSeed GetSeedToNewTarget(IEnumerable<ArticleTarget> targetList, ContractCode contract, PositionCode position, ExtendedCode code)
        {
            IEnumerable<ArticleTarget> selectedTargets = SelectEquals(targetList, contract, position, code);

            IEnumerable<ExtendedSeed> oneCodeSeeds = ExtractCodeSeed(selectedTargets);

            return NewSeqSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static private IEnumerable<ArticleTarget> SelectEquals(IEnumerable<ArticleTarget> targetList, ContractCode contract, PositionCode position, ExtendedCode code)
        {
            return targetList.Where(x => (EqualitySelector(x, contract, position, code))).ToList();
        }

        static private IEnumerable<ExtendedSeed> ExtractCodeSeed(IEnumerable<ArticleTarget> selectedTargets)
        {
            return selectedTargets.Select(x => x.Seed).ToList();
        }

        static private ExtendedSeed FirstSeedFromList(IEnumerable<ExtendedSeed> selectedSeeds)
        {
            ExtendedSeed firstSeed = selectedSeeds.DefaultIfEmpty(TargetConst.TARGET_SEED_FIRST).First();

            return firstSeed;
        }

        static private ExtendedSeed NewSeqSeedFromList(IEnumerable<ExtendedSeed> selectedSeeds)
        {
            ExtendedSeed lastSeed = selectedSeeds.Aggregate(TargetConst.TARGET_SEED_NULL, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));

            return (ExtendedSeed)(lastSeed + 1);
        }

        public static bool EqualitySelector(ArticleTarget target, ContractCode contract, PositionCode position, ExtendedCode code)
        {
            return (target.Contract == contract && target.Position == position && target.Code == code);
        }

    }
}
