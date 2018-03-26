using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = ArticleCode;
    using TargetSeed = UInt16;

    public class TargetSelector
    {
        static public TargetSeed GetFirstTargetSeed(IEnumerable<ArticleTarget> targetList, ContractCode contract, PositionCode position, TargetCode code)
        {
            IEnumerable<ArticleTarget> selectedTargets = SelectEquals(targetList, contract, position, code);

            IEnumerable<TargetSeed> oneCodeSeeds = ExtractCodeSeed(selectedTargets);

            return FirstSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static public TargetSeed GetSeedToNewTarget(IEnumerable<ArticleTarget> targetList, ContractCode contract, PositionCode position, TargetCode code)
        {
            IEnumerable<ArticleTarget> selectedTargets = SelectEquals(targetList, contract, position, code);

            IEnumerable<TargetSeed> oneCodeSeeds = ExtractCodeSeed(selectedTargets);

            return NewSeqSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static private IEnumerable<ArticleTarget> SelectEquals(IEnumerable<ArticleTarget> targetList, ContractCode contract, PositionCode position, TargetCode code)
        {
            return targetList.Where(x => (EqualitySelector(x, contract, position, code))).ToList();
        }

        static private IEnumerable<TargetSeed> ExtractCodeSeed(IEnumerable<ArticleTarget> selectedTargets)
        {
            return selectedTargets.Select(x => x.Seed).ToList();
        }

        static private TargetSeed FirstSeedFromList(IEnumerable<TargetSeed> selectedSeeds)
        {
            TargetSeed firstSeed = selectedSeeds.DefaultIfEmpty(TargetConst.TARGET_SEED_FIRST).First();

            return firstSeed;
        }

        static private TargetSeed NewSeqSeedFromList(IEnumerable<TargetSeed> selectedSeeds)
        {
            TargetSeed lastSeed = selectedSeeds.Aggregate(TargetConst.TARGET_SEED_NULL, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));

            return (TargetSeed)(lastSeed + 1);
        }

        public static bool EqualitySelector(ArticleTarget target, ContractCode contract, PositionCode position, TargetCode code)
        {
            return (target.Contract == contract && target.Position == position && target.Code == code);
        }

    }
}
