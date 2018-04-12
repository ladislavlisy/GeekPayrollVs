using System;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.Matrixus.Config
{
    using BodyCode = UInt16;
    using BodyRole = UInt16;
    using BodyType = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleConfig;
    using BodyPair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleConfig>;

    using Module.Interfaces.Elements;
    using Module.Codes;
    using Module.Json;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        public IEnumerable<BodyPair> CreateConfigList()
        {
            return ArticleCodeAdapter.GetConfigurationList();
        }
        public BodyItem CreateConfigItem(ArticleConfigNameJson configJson)
        {
            BodyCode code = ArticleCodeAdapter.CreateCode(configJson.Code);

            BodyRole role = ArticleRoleAdapter.CreateCode(configJson.Role);

            BodyType type = 0;


            BodyCode[] path = configJson.ResolvePath.Select((p) => (ArticleCodeAdapter.CreateCode(p))).ToArray();

            ArticleConfig config = new ArticleConfig(code, role, type, path);

            return config;
        }
        public BodyCode CreateConfigCode(ArticleConfigNameJson configJson)
        {
            BodyCode code = ArticleCodeAdapter.CreateCode(configJson.Code);

            return code;
        }
    }
}
