using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigRoleItem = IArticleRoleConfig;
    using ConfigRoleData = Interfaces.Permadom.ArticleRoleConfigData;

    using ConfigCodeItem = IArticleCodeConfig;
    using ConfigCodeData = Interfaces.Permadom.ArticleCodeConfigData;

    public interface IArticleConfigFactory
    {
        ConfigRoleItem CreateConfigRoleItem(ConfigRoleData configData);
        ConfigCodeItem CreateConfigCodeItem(ConfigCodeData configData);
    }
}
