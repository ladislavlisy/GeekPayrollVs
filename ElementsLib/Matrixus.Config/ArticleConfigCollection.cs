using System;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.IArticleConfig;
    using ConfigPair = KeyValuePair<UInt16, Module.Interfaces.IArticleConfig>;

    using Module.Common;
    using Module.Interfaces;
    using Module.Libs;
    using Module.Codes;
    using Module.Json;

    public class ArticleConfigCollection : GeneralConfigCollection<ConfigItem, ConfigCode>
    {
        public ArticleConfigCollection() : base()
        {
        }

        public void LoadConfigJson(IList<ArticleConfigNameJson> configList, IArticleConfigFactory configFactory)
        {
            IEnumerable<ConfigPair> configTypeList = configList.Select((c) => (new ConfigPair(
                configFactory.CreateConfigCode(c), configFactory.CreateConfigItem(c)))).ToList();

            ConfigureModel(configTypeList);

            ConfigureModelPath();
        }

        public void InitConfigModel(IArticleConfigFactory configFactory)
        {
            IEnumerable<ConfigPair> configTypeList = configFactory.CreateConfigList();

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

            var ModelOrderDict = Models.Aggregate(resultsZero, (agr, c) => agr.Merge(c.Value.Code(), ResolveModelPath(agr, c.Value.Code(), c.Value.Path(), Models)));

            IList<ConfigCode> TempModelPath = Models.Keys.ToList();

            ModelPath = TempModelPath.OrderBy((x) => (x), new CompareConfigCode(ModelOrderDict)).ToList();
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
