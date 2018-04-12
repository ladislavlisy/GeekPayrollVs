﻿using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.Elements
{
    using MarkName = String;
    using BodyCode = UInt16;

    using TempDict = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using TargetVals = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using TargetPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;

    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;

    using SortedPair = KeyValuePair<UInt16, Int32>;

    using Module.Interfaces.Elements;
    using Module.Codes;
    using Config;
    using Exceptions;
    using Module.Interfaces.Matrixus;
    using ResultMonad;

    public class ArticleBucket : AbstractArticleBucket
    {
        public ArticleBucket(TempDict templates) : base(templates)
        {
        }

        public override BodyCode GetHeadBodyCode()
        {
            return ArticleCodeAdapter.GetContractCode();
        }

        public override BodyCode GetPartBodyCode()
        {
            return ArticleCodeAdapter.GetPositionCode();
        }

        public override IList<TargetPair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler, BodyCode contractCode, BodyCode positionCode)
        {
            IEnumerable<IArticleTarget> targetsInit = GetTargets();
            IEnumerable<IArticleTarget> targetsCalc = configBundler.GetTargets(targetsInit, contractCode, positionCode);
            IList<SortedPair> modelPath = configBundler.ModelPath();

            ComplementTrace(targetsCalc);

            IList<IArticleTarget> sortedTargets = Keys.OrderBy((x) => (x), new CompareEvaluationTargets(modelPath)).ToList();

            return sortedTargets.Select((s) => (model.SingleOrDefault((kv) => (kv.Key.CompareTo(s) == 0)))).ToList();
        }
    }

    internal class CompareEvaluationTargets : IComparer<TargetItem>
    {
        private IList<SortedPair> ModelOrderList;

        public CompareEvaluationTargets(IList<SortedPair> modelOrderList)
        {
            this.ModelOrderList = modelOrderList;
        }

        public int Compare(TargetItem x, TargetItem y)
        {
            if (x == y)
            {
                return 0;
            }

            SortedPair xResolve = ModelOrderList.SingleOrDefault((xk) => (xk.Key == x.Code()));

            Int32 xResolverOrder = 0;
            if (xResolve.Key == x.Code())
            {
                xResolverOrder = xResolve.Value;
            }

            SortedPair yResolve = ModelOrderList.SingleOrDefault((yk) => (yk.Key == y.Code()));

            Int32 yResolverOrder = 0;
            if (yResolve.Key == y.Code())
            {
                yResolverOrder = yResolve.Value;
            }

            int compareCode = xResolverOrder.CompareTo(yResolverOrder);
            if (compareCode != 0)
            {
                return compareCode;
            }
            compareCode = x.Head().CompareTo(y.Head());
            if (compareCode != 0)
            {
                return compareCode;
            }
            compareCode = x.Part().CompareTo(y.Part());
            if (compareCode != 0)
            {
                return compareCode;
            }
            compareCode = x.Seed().CompareTo(y.Seed());
            return compareCode;
        }
    }
}
