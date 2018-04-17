using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigRole = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleRoleConfig;
    using ConfigData = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using Elements;

    public interface IArticleRoleCollection : IConfigCollection<ConfigItem, ConfigRole>
    {
        void LoadConfigData(IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory);
    }
}
