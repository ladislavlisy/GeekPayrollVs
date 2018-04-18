﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Matrixus.IArticleConfigDetail;
    using ConfigPair = KeyValuePair<UInt16, Module.Interfaces.Matrixus.IArticleConfigDetail>;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourceErrs = String;

    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using ConfigType = UInt16;
    using TargetSeed = UInt16;

    using Module.Libs;
    using Module.Codes;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using Elements;
    using Elements.Config;

    public class ArticleDetailCollection : GeneralConfigCollection<ConfigItem, ConfigCode>, IArticleDetailCollection
    {
        public ArticleDetailCollection() : base()
        {
            this.InternalModelResolve = new Dictionary<ConfigCode, IEnumerable<ConfigCode>>();
        }

        protected IDictionary<ConfigCode, IEnumerable<ConfigCode>> InternalModelResolve { get; set; }

        public void LoadConfigData(IArticleMasterCollection masterStore, IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory)
        {
            IEnumerable<ConfigPair> configTypeList = configList.Select((c) => (new ConfigPair(
                c.Code, configFactory.CreateDetailItem(masterStore, c.Code, c.Name, c.Role, c.Type, c.Path)))).ToList();

            ConfigureModel(configTypeList);

            ConfigureModelPath();
        }

        public ConfigItem FindArticleConfig(ConfigCode modelCode)
        {
            ConfigItem configModel = FindConfigByCode(modelCode);

            return configModel;
        }
        public ResultMonad.Result<SourceItem, SourceErrs> FindArticleSource(ConfigCode modelCode)
        {
            ConfigItem configModel = FindConfigByCode(modelCode);

            if (configModel == null)
            {
                return ResultMonad.Result.Fail<SourceItem, SourceErrs>("Config model doesn't exist!"); ;
            }
            if (configModel.Stub() == null)
            {
                return ResultMonad.Result.Fail<SourceItem, SourceErrs>("Config source doesn't exist!"); ;
            }
            return ResultMonad.Result.Ok<SourceItem, SourceErrs>(configModel.Stub());
        }
        public ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals)
        {
            ResultMonad.Result<SourceItem, SourceErrs> emptyInstance = FindArticleSource(configCode);

            if (emptyInstance.IsFailure)
            {
                return emptyInstance;
            }
            return emptyInstance.Value.CloneSourceAndSetValues<SourceItem>(sourceVals);
        }

        protected void ConfigureModelPath()
        {
            IDictionary<ConfigCode, IEnumerable<ConfigCode>> resultsZero = new Dictionary<ConfigCode, IEnumerable<ConfigCode>>();

            InternalModelResolve = InternalModels.Aggregate(resultsZero, (agr, c) => agr.Merge(c.Value.Code(), ResolveModelPath(agr, c.Value.Code(), c.Value.Path(), InternalModels)));

            IList<ConfigCode> TempModelPath = InternalModels.Keys.ToList();

            InternalModelPath = TempModelPath.OrderBy((x) => (x), new CompareConfigCode(InternalModelResolve)).Select((k, i) => (new KeyValuePair<ConfigCode, Int32>(k, i))).ToList();
        }

        protected ConfigCode[] ResolveModelPath(IDictionary<ConfigCode, IEnumerable<ConfigCode>> resultsHead, ConfigCode articleCode, IEnumerable<ConfigCode> articlePath, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            IDictionary<ConfigCode, IEnumerable<ConfigCode>> resultsSink = new Dictionary<ConfigCode, IEnumerable<ConfigCode>>();

            ConfigCode[] articleSubs = new ConfigCode[0];

            IDictionary<ConfigCode, IEnumerable<ConfigCode>> articleIter = articlePath.Aggregate(resultsSink, (agr, c) => ResolveModelIter(resultsHead, c, articleSubs, agr, articleTree));

            ConfigCode[] resultsList = articleIter.SelectMany((c) => (c.Value.Merge(c.Key))).OrderBy(s => s).Distinct().ToArray();

            return resultsList.ToArray();
        }

        protected IDictionary<ConfigCode, IEnumerable<ConfigCode>> ResolveModelIter(IDictionary<ConfigCode, IEnumerable<ConfigCode>> resultsHead, ConfigCode resolveCode, IEnumerable<ConfigCode> articlePath, IDictionary<ConfigCode, IEnumerable<ConfigCode>> resultsSink, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            if (articlePath.Contains(resolveCode))
            {
                // Error - cyclic dependency
                return resultsSink.Merge(resolveCode, new ConfigCode[0]);
            }

            ConfigCode[] articleSubs = articlePath.Merge(resolveCode).ToArray();

            IEnumerable<ConfigCode> pathHead;
            bool foundHead = resultsHead.TryGetValue(resolveCode, out pathHead);

            if (foundHead && pathHead != null)
            {
                return resultsSink.Merge(resolveCode, pathHead);
            }

            IEnumerable<ConfigCode> pathSink;
            bool foundSink = resultsSink.TryGetValue(resolveCode, out pathSink);

            if (foundSink && pathSink != null)
            {
                return resultsSink;
            }

            ConfigCode[] pathTree = ResolveModelCode(resolveCode, articleTree);

            IDictionary<ConfigCode, IEnumerable<ConfigCode>> codeSink = resultsSink.Merge(resolveCode, pathTree);

            IDictionary<ConfigCode, IEnumerable<ConfigCode>> resolveSink = pathTree.Aggregate(codeSink, (agr, c) => ResolveModelIter(resultsHead, c, articleSubs, agr, articleTree));

            return resolveSink;
        }

        public IEnumerable<IArticleTarget> GetTargets(IEnumerable<IArticleTarget> targetsInit, ConfigCode headCode, ConfigCode partCode)
        {
            IEnumerable<IArticleTarget> targetssZero = new List<IArticleTarget>();

            var contractsHead = targetsInit.Where((ch) => (ch.Code() == headCode)).Select((cv) => (cv.Seed()));
            var positionsPart = targetsInit.Where((ch) => (ch.Code() == partCode)).Select((cv) => new Tuple<TargetHead, TargetPart>(cv.Head(), cv.Seed()));

            IEnumerable<IArticleTarget> targetsCalc = targetsInit.Aggregate(targetssZero, (agr, d) => agr.Concat(ResolveTargets(d, contractsHead, positionsPart, InternalModelResolve)));

            return targetsCalc.Distinct();
        }

        private IEnumerable<IArticleTarget> ResolveTargets(IArticleTarget target, IEnumerable<TargetHead> contractsHead, IEnumerable<Tuple<TargetHead, TargetPart>> positionsPart, IDictionary<ushort, IEnumerable<ushort>> modelResolve)
        {
            IEnumerable<ConfigCode> configResolve = modelResolve.FirstOrDefault((kvx) => (kvx.Key == target.Code())).Value.ToList();

            IEnumerable<IArticleTarget> targetResolve = configResolve.SelectMany((c) => (CreateTarget(c, target, contractsHead, positionsPart, InternalModels))).ToList();

            return targetResolve.Where((c) => (c.Code() != 0));
        }

        private IEnumerable<ArticleTarget> CreateTarget(ConfigCode codeConfig, IArticleTarget target, IEnumerable<TargetHead> contractsHead, IEnumerable<Tuple<TargetHead, TargetPart>> positionsPart, IDictionary<ConfigCode, ConfigItem> models)
        {
            IEnumerable<ArticleTarget> targetList = new List<ArticleTarget>();

            ConfigItem configItem = models.FirstOrDefault((c) => (c.Key == codeConfig)).Value;

            TargetHead codeHead = 0;
            TargetPart codePart = 0;
            ConfigCode codeBody = codeConfig;
            TargetSeed seedBody = 0;

            if (configItem.Type() == (ConfigType)ArticleType.NO_HEAD_PART_TYPE)
            {
                targetList = new List<ArticleTarget>() { new ArticleTarget(codeHead, codePart, codeBody, seedBody) };
            }
            if (configItem.Type() == (ConfigType)ArticleType.HEAD_CODE_ARTICLE)
            {
                if (target.Head() != 0)
                {
                    codeHead = target.Head();
                    targetList = new List<ArticleTarget>() { new ArticleTarget(codeHead, codePart, codeBody, seedBody) };
                }
                else
                {
                    targetList = contractsHead.Select((ch) => (new ArticleTarget(ch, codePart, codeBody, seedBody))).ToList();
                }
            }
            else if (configItem.Type() == (ConfigType)ArticleType.PART_CODE_ARTICLE)
            {
                if (target.Head() != 0 && target.Part() != 0)
                {
                    codeHead = target.Head();
                    codePart = target.Part();
                    targetList = new List<ArticleTarget>() { new ArticleTarget(codeHead, codePart, codeBody, seedBody) };
                }
                else
                {
                    targetList = positionsPart.Select((pp) => (new ArticleTarget(pp.Item1, pp.Item2, codeBody, seedBody))).ToList();
                }
            }

            return targetList;
        }

        protected ConfigCode[] ResolveModelCode(ConfigCode resolveCode, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            ConfigItem articleItem;
            bool foundTree = articleTree.TryGetValue(resolveCode, out articleItem);

            if (foundTree == false || articleItem == null)
            {
                // Not Found in Config
                return new ConfigCode[0];
            }

            return articleItem.Path();
        }

        public string Description(IDictionary<ConfigCode, IEnumerable<ConfigCode>> articleSink)
        {
            return articleSink.Aggregate("", (agr, a) => (string.Format("{0}\n{1}{2}\n", agr, ArticleCodeAdapter.CreateEnum(a.Key).GetSymbol(),
                a.Value.Aggregate("", (bgr, b) => (string.Format("{0}\n={1}", bgr, ArticleCodeAdapter.CreateEnum(b).GetSymbol()))))));
        }
        private string DescriptionPath(IEnumerable<ConfigCode> articlePath)
        {
            return articlePath.Aggregate("", (agr, a) => (string.Format("{0}{1}\n", agr, ArticleCodeAdapter.CreateEnum(a).GetSymbol())));
        }
    }

    internal class CompareConfigCode : IComparer<ConfigCode>
    {
        private IDictionary<ushort, IEnumerable<ushort>> ModelOrderDict;

        public CompareConfigCode(IDictionary<ushort, IEnumerable<ushort>> modelOrderDict)
        {
            this.ModelOrderDict = modelOrderDict;
        }

        public int Compare(ushort x, ushort y)
        {
            if (x == y)
            {
                return 0;
            }

            IEnumerable<ConfigCode> xResolve;
            bool foundX = ModelOrderDict.TryGetValue(x, out xResolve);

            if (foundX == false || xResolve == null)
            {
                xResolve = new ConfigCode[0];
            }

            IEnumerable<ConfigCode> yResolve;
            bool foundY = ModelOrderDict.TryGetValue(y, out yResolve);

            if (foundY == false || yResolve == null)
            {
                yResolve = new ConfigCode[0];
            }

            bool xDependsOnY = xResolve.Contains(y);

            bool yDependsOnX = yResolve.Contains(x);

            if (xDependsOnY)
            {
                return 1;
            }

            if (yDependsOnX)
            {
                return -1;
            }

            if (xResolve.Count() != yResolve.Count())
            {
                return xResolve.Count().CompareTo(yResolve.Count());
            }

            return x.CompareTo(y);
        }
    }
}