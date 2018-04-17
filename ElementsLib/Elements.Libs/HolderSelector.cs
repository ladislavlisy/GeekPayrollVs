using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Libs
{
    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigCode = UInt16;
    using HolderSeed = UInt16;

    using Module.Interfaces.Elements;

    public static class HolderSelector
    {
        static public HolderSeed GetFirstHolderSeed(IEnumerable<IArticleHolder> holderList, HolderHead codeHead, HolderPart codePart, ConfigCode codeBody)
        {
            IEnumerable<IArticleHolder> selectedHolders = SelectEquals(holderList, codeHead, codePart, codeBody);

            IEnumerable<HolderSeed> oneCodeSeeds = ExtractCodeSeed(selectedHolders);

            return FirstSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static public HolderSeed GetSeedToNewHolder(IEnumerable<IArticleHolder> holderList, HolderHead codeHead, HolderPart codePart, ConfigCode codeBody)
        {
            IEnumerable<IArticleHolder> selectedHolders = SelectEquals(holderList, codeHead, codePart, codeBody);

            IEnumerable<HolderSeed> oneCodeSeeds = ExtractCodeSeed(selectedHolders);

            return NewSeqSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static private IEnumerable<IArticleHolder> SelectEquals(IEnumerable<IArticleHolder> holderList, HolderHead codeHead, HolderPart codePart, ConfigCode codeBody)
        {
            return holderList.Where(x => (EqualitySelector(x, codeHead, codePart, codeBody))).ToList();
        }

        static private IEnumerable<HolderSeed> ExtractCodeSeed(IEnumerable<IArticleHolder> selectedHolders)
        {
            return selectedHolders.Select(x => x.Seed()).ToList();
        }

        static private HolderSeed FirstSeedFromList(IEnumerable<HolderSeed> selectedSeeds)
        {
            HolderSeed firstSeed = selectedSeeds.DefaultIfEmpty(ArticleHolder.BODY_SEED_FIRST).First();

            return firstSeed;
        }

        static private HolderSeed NewSeqSeedFromList(IEnumerable<HolderSeed> selectedSeeds)
        {
            HolderSeed lastSeed = selectedSeeds.Aggregate(ArticleHolder.BODY_SEED_NULL, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));

            return (HolderSeed)(lastSeed + 1);
        }

        public static bool EqualitySelector(IArticleHolder target, HolderHead codeHead, HolderPart codePart, ConfigCode codeBody)
        {
            return (target.Head() == codeHead && target.Part() == codePart && target.Code() == codeBody);
        }

    }
}
