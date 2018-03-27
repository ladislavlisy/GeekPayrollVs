using System;

namespace ElementsLib
{
    using ConfigCode = UInt16;

    using Common;
    using Interfaces;
    using ModuleConfig.Json;
    using System.Collections.Generic;

    public class ArticlesConfigCollection : GeneralConfigCollection<IArticleConfig, ConfigCode>
    {
        public ArticlesConfigCollection() : base()
        {
        }

        public void LoadConfigJson(IList<ArticleConfigJson> configList, IArticleConfigFactory configFactory)
        {
            foreach (var config in configList)
            {
                ArticleConfig configModel = configFactory.CreateConfig(config);

                ConfigureModel(configModel, configModel.Code);
            }
        }

        public IArticleConfig FindArticleConfig(ConfigCode modelCode)
        {
            IArticleConfig configModel = FindInstanceForCode(modelCode);

            return configModel;
        }
    }
}
