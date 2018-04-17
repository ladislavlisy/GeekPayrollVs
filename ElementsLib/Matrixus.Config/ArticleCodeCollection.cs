using System;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleCodeConfig;
    using ConfigPair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleCodeConfig>;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigType = UInt16;
    using HolderSeed = UInt16;

    using Module.Libs;
    using Module.Codes;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using Elements;
    using Elements.Config;

    public class ArticleCodeCollection : GeneralConfigCollection<ConfigItem, ConfigCode>, IArticleCodeCollection
    {
        public ArticleCodeCollection() : base()
        {
            this.InternalModelResolve = new Dictionary<ConfigCode, IEnumerable<ConfigCode>>();
        }

        protected IDictionary<ConfigCode, IEnumerable<ConfigCode>> InternalModelResolve { get; set; }

        public void LoadConfigData(IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory)
        {
            IEnumerable<ConfigPair> configTypeList = configList.Select((c) => (new ConfigPair(
                c.Code, configFactory.CreateConfigCodeItem(c)))).ToList();

            ConfigureModel(configTypeList);

            ConfigureModelPath();
        }

        public ConfigItem FindArticleConfig(ConfigCode modelCode)
        {
            ConfigItem configModel = FindConfigByCode(modelCode);

            return configModel;
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

        public IEnumerable<IArticleHolder> GetHolders(IEnumerable<IArticleHolder> holdersInit, ConfigCode headCode, ConfigCode partCode)
        {
            IEnumerable<IArticleHolder> holderssZero = new List<IArticleHolder>();

            var contractsHead = holdersInit.Where((ch) => (ch.Code() == headCode)).Select((cv) => (cv.Seed()));
            var positionsPart = holdersInit.Where((ch) => (ch.Code() == partCode)).Select((cv) => new Tuple<HolderHead, HolderPart>(cv.Head(), cv.Seed()));

            IEnumerable<IArticleHolder> holdersCalc = holdersInit.Aggregate(holderssZero, (agr, d) => agr.Concat(ResolveHolders(d, contractsHead, positionsPart, InternalModelResolve)));

            return holdersCalc.Distinct();
        }

        private IEnumerable<IArticleHolder> ResolveHolders(IArticleHolder holder, IEnumerable<HolderHead> contractsHead, IEnumerable<Tuple<HolderHead, HolderPart>> positionsPart, IDictionary<ushort, IEnumerable<ushort>> modelResolve)
        {
            IEnumerable<ConfigCode> configResolve = modelResolve.FirstOrDefault((kvx) => (kvx.Key == holder.Code())).Value.ToList();

            IEnumerable<IArticleHolder> holderResolve = configResolve.SelectMany((c) => (CreateHolder(c, holder, contractsHead, positionsPart, InternalModels))).ToList();

            return holderResolve.Where((c) => (c.Code() != 0));
        }

        private IEnumerable<ArticleHolder> CreateHolder(ConfigCode codeConfig, IArticleHolder holder, IEnumerable<HolderHead> contractsHead, IEnumerable<Tuple<HolderHead, HolderPart>> positionsPart, IDictionary<ConfigCode, ConfigItem> models)
        {
            IEnumerable<ArticleHolder> holderList = new List<ArticleHolder>();

            ConfigItem configItem = models.FirstOrDefault((c) => (c.Key == codeConfig)).Value;

            HolderHead codeHead = 0;
            HolderPart codePart = 0;
            ConfigCode codeBody = codeConfig;
            HolderSeed seedBody = 0;

            if (configItem.Type() == (ConfigType)ArticleType.NO_HEAD_PART_TYPE)
            {
                holderList = new List<ArticleHolder>() { new ArticleHolder(codeHead, codePart, codeBody, seedBody) };
            }
            if (configItem.Type() == (ConfigType)ArticleType.HEAD_CODE_ARTICLE)
            {
                if (holder.Head() != 0)
                {
                    codeHead = holder.Head();
                    holderList = new List<ArticleHolder>() { new ArticleHolder(codeHead, codePart, codeBody, seedBody) };
                }
                else
                {
                    holderList = contractsHead.Select((ch) => (new ArticleHolder(ch, codePart, codeBody, seedBody))).ToList();
                }
            }
            else if (configItem.Type() == (ConfigType)ArticleType.PART_CODE_ARTICLE)
            {
                if (holder.Head() != 0 && holder.Part() != 0)
                {
                    codeHead = holder.Head();
                    codePart = holder.Part();
                    holderList = new List<ArticleHolder>() { new ArticleHolder(codeHead, codePart, codeBody, seedBody) };
                }
                else
                {
                    holderList = positionsPart.Select((pp) => (new ArticleHolder(pp.Item1, pp.Item2, codeBody, seedBody))).ToList();
                }
            }

            return holderList;
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
