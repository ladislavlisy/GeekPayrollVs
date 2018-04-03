using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigItem = IArticleConfig;
    using ConfigPair = KeyValuePair<UInt16, IArticleConfig>;

    using Json;

    public interface IArticleConfigFactory
    {
        IEnumerable<ConfigPair> CreateConfigList();
        ConfigItem CreateConfigItem(ArticleConfigNameJson configJson);
        ConfigCode CreateConfigCode(ArticleConfigNameJson configJson);
    }
}
