using System;
using System.Collections.Generic;

namespace ElementsLib.Interfaces
{
    using ConfigCode = UInt16;
    using ConfigItem = IArticleConfig;
    using ConfigPair = KeyValuePair<UInt16, IArticleConfig>;

    using ModuleConfig.Json;

    public interface IArticleConfigFactory
    {
        IEnumerable<ConfigPair> CreateConfigList();
        ConfigItem CreateConfigItem(ArticleConfigNameJson configJson);
        ConfigCode CreateConfigCode(ArticleConfigNameJson configJson);
    }
}
