using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Matrixus.IArticleTarget;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using Elements;
    using System.Reflection;

    public interface IArticleCodeCollection : IConfigCollection<ConfigItem, ConfigCode>
    {
        void LoadConfigData(Assembly configAssembly, IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory);
        IEnumerable<IArticleHolder> GetHolders(IEnumerable<IArticleHolder> holdersInit, ConfigCode headCode, ConfigCode partCode);
    }
}
