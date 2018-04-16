using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using Elements;

    public interface IArticleConfigCollection : IConfigCollection<ConfigItem, ConfigCode>
    {
        void LoadConfigData(IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory);
    }
}
