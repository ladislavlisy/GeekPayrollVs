using System;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.ModuleConfig
{
    using ConfigCode = UInt16;
    using ConfigItem = Interfaces.IArticleConfig;
    using ConfigPair = KeyValuePair<UInt16, Interfaces.IArticleConfig>;

    using Common;
    using Interfaces;
    using ModuleConfig.Json;
    using ElementsLib.Libs;

    public class ArticlesConfigCollection : GeneralConfigCollection<ConfigItem, ConfigCode>
    {
        public ArticlesConfigCollection() : base()
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
            IDictionary<ConfigCode, IEnumerable<ConfigCode>> articleZero = new Dictionary<ConfigCode, IEnumerable<ConfigCode>>();

            ModelPath = Models.Keys.ToList();

            var ModelOrderDict = Models.Aggregate(articleZero, (agr, c) => agr.Merge(c.Value.Code(), ResolveModelPath(c.Value.Code(), c.Value.Path(), Models)));

            return;
        }

        protected ConfigCode[] ResolveModelPath(ConfigCode articleCode, IEnumerable<ConfigCode> articlePath, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            return ResolveModelHead(articleCode, articlePath, articleTree);
        }

        protected ConfigCode[] ResolveModelHead(ConfigCode resolveCode, IEnumerable<ConfigCode> articlePath, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            IDictionary<ConfigCode, IEnumerable<ConfigCode>> articleSink = new Dictionary<ConfigCode, IEnumerable<ConfigCode>>();

            ConfigCode[] articleSubs = new ConfigCode[0];

            IDictionary<ConfigCode, IEnumerable<ConfigCode>> articleIter = articlePath.Aggregate(articleSink, (agr, c) => ResolveModelIter(c, articleSubs, agr, articleTree));

            IEnumerable<ConfigCode> articleList;
            bool found = articleIter.TryGetValue(resolveCode, out articleList);

            if (found == false || articleList == null)
            {
                return new ConfigCode[0];
            }

            return articleList.ToArray();
        }

        protected ConfigCode[] ResolveModelCode(ConfigCode articleCode, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            ConfigItem articleItem;
            bool found = articleTree.TryGetValue(articleCode, out articleItem);

            if (found == false || articleItem == null)
            {
                return new ConfigCode[0];
            }

            var articlePath = articleItem.Path();

            return articlePath;
        }
        protected IDictionary<ConfigCode, IEnumerable<ConfigCode>> ResolveModelIter(ConfigCode resolveCode, IEnumerable<ConfigCode> articlePath, IDictionary<ConfigCode, IEnumerable<ConfigCode>> articleSink, IDictionary<ConfigCode, ConfigItem> articleTree)
        {
            if (articlePath.Contains(resolveCode))
            {
                return articleSink.Merge(resolveCode, new ConfigCode[0]);
            }
            IEnumerable<ConfigCode> pathSink;
            bool foundSink = articleSink.TryGetValue(resolveCode, out pathSink);

            if (foundSink || pathSink != null)
            {
                return articleSink;
            }

            ConfigItem articleItem = null;
            bool foundTree = articleTree.TryGetValue(resolveCode, out articleItem);

            if (foundTree == false || articleItem == null)
            {
                return articleSink.Merge(resolveCode, new ConfigCode[0]);
            }

            ConfigCode[] pathTree = articleItem.Path();

            ConfigCode[] articleSubs = articlePath.Merge(resolveCode).ToArray();

            IDictionary<ConfigCode, IEnumerable<ConfigCode>> codeSink = articleSink.Merge(resolveCode, pathTree);

            IDictionary<ConfigCode, IEnumerable<ConfigCode>> resultsSink = pathTree.Aggregate(codeSink, (agr, c) => ResolveModelIter(c, articleSubs, agr, articleTree));

            return resultsSink;
        }
    }
}
