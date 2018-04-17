using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using ConfigRole = UInt16;
    using ConfigItem = Module.Interfaces.Matrixus.IArticleMethod;
    using ConfigData = Module.Interfaces.Permadom.ArticleRoleConfigData;
    using ConfigPair = KeyValuePair<UInt16, Module.Interfaces.Matrixus.IArticleMethod>;

    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using Elements.Config;
    using Module.Codes;
    using System.Reflection;

    public class ArticleRoleCollection : GeneralConfigCollection<ConfigItem, ConfigRole>, IArticleRoleCollection
    {
        public ArticleRoleCollection() : base()
        {
        }

        public void LoadConfigData(Assembly configAssembly, IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory)
        {
            IEnumerable<ConfigPair> configTypeList = configList.Select((c) => (new ConfigPair(
                c.Role, configFactory.CreateMethodItem(configAssembly, c.Role, c.Name, c.Path)))).ToList();

            ConfigureModel(configTypeList);
        }

        public ConfigItem FindArticleConfig(ConfigRole modelRole)
        {
            ConfigItem configModel = FindConfigByCode(modelRole);

            return configModel;
        }
    }
}
