using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Matrixus.IArticleConfigDetail;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourceErrs = String;

    using Elements;
    using System.Reflection;

    public interface IArticleDetailCollection : IConfigCollection<ConfigItem, ConfigCode>
    {
        void LoadConfigData(IArticleMasterCollection masterStore, IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory);
        IEnumerable<IArticleTarget> GetTargets(IEnumerable<IArticleTarget> targetsInit, ConfigCode headCode, ConfigCode partCode);
        ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals);
    }
}
