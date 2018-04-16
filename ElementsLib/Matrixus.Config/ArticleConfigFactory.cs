using System;

namespace ElementsLib.Matrixus.Config
{
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using Module.Interfaces.Elements;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        public ConfigItem CreateConfigItem(ConfigData codeData)
        {
            ArticleConfig config = new ArticleConfig(codeData.Code, codeData.Role, codeData.Type, codeData.Name, codeData.Path);

            return config;
        }
    }
}
