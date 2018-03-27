using System;
using System.Linq;

namespace ElementsLib
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using Interfaces;
    using ModuleConfig.Json;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        public ArticleConfig CreateConfig(ArticleConfigJson configJson)
        {
            ConfigCode code = ArticleCodeFactory.CreateCode(configJson.Code);

            ConfigRole role = ArticleRoleFactory.CreateCode(configJson.Role);

            ConfigCode[] path = configJson.ResolvePath.Select((p) => (ArticleCodeFactory.CreateCode(p))).ToArray();

            ArticleConfig config = new ArticleConfig(code, role, path);

            return config;
        }

    }
}
