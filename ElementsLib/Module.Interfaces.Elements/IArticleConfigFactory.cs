using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    using BodyItem = IArticleConfig;
    using BodyPair = KeyValuePair<UInt16, IArticleConfig>;

    using Json;

    public interface IArticleConfigFactory
    {
        IEnumerable<BodyPair> CreateConfigList();
        BodyItem CreateConfigItem(ArticleConfigNameJson configJson);
        BodyCode CreateConfigCode(ArticleConfigNameJson configJson);
    }
}
