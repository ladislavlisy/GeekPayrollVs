using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigItem = IArticleConfig;
    using ConfigData = Interfaces.Permadom.ArticleCodeConfigData;

    public interface IArticleConfigFactory
    {
        ConfigItem CreateConfigItem(ConfigData configJson);
    }
}
