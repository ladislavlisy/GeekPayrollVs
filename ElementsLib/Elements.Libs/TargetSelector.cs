﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Libs
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;

    using Module.Interfaces.Elements;

    public static class TargetSelector
    {
        static public BodySeed GetFirstTargetSeed(IEnumerable<IArticleTarget> targetList, HeadCode codeHead, PartCode codePart, BodyCode codeBody)
        {
            IEnumerable<IArticleTarget> selectedTargets = SelectEquals(targetList, codeHead, codePart, codeBody);

            IEnumerable<BodySeed> oneCodeSeeds = ExtractCodeSeed(selectedTargets);

            return FirstSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static public BodySeed GetSeedToNewTarget(IEnumerable<IArticleTarget> targetList, HeadCode codeHead, PartCode codePart, BodyCode codeBody)
        {
            IEnumerable<IArticleTarget> selectedTargets = SelectEquals(targetList, codeHead, codePart, codeBody);

            IEnumerable<BodySeed> oneCodeSeeds = ExtractCodeSeed(selectedTargets);

            return NewSeqSeedFromList(oneCodeSeeds.OrderBy(x => x).ToArray());
        }

        static private IEnumerable<IArticleTarget> SelectEquals(IEnumerable<IArticleTarget> targetList, HeadCode codeHead, PartCode codePart, BodyCode codeBody)
        {
            return targetList.Where(x => (EqualitySelector(x, codeHead, codePart, codeBody))).ToList();
        }

        static private IEnumerable<BodySeed> ExtractCodeSeed(IEnumerable<IArticleTarget> selectedTargets)
        {
            return selectedTargets.Select(x => x.Seed()).ToList();
        }

        static private BodySeed FirstSeedFromList(IEnumerable<BodySeed> selectedSeeds)
        {
            BodySeed firstSeed = selectedSeeds.DefaultIfEmpty(ArticleTarget.BODY_SEED_FIRST).First();

            return firstSeed;
        }

        static private BodySeed NewSeqSeedFromList(IEnumerable<BodySeed> selectedSeeds)
        {
            BodySeed lastSeed = selectedSeeds.Aggregate(ArticleTarget.BODY_SEED_NULL, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));

            return (BodySeed)(lastSeed + 1);
        }

        public static bool EqualitySelector(IArticleTarget target, HeadCode codeHead, PartCode codePart, BodyCode codeBody)
        {
            return (target.Head() == codeHead && target.Part() == codePart && target.Code() == codeBody);
        }

    }
}
