using System;
using System.Collections.Generic;
using System.Reflection;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigType = UInt16;

    using DetailData = IEnumerable<Permadom.ArticleCodeConfigData>;
    using MasterData = IEnumerable<Permadom.ArticleRoleConfigData>;

    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourceErrs = String;


    public interface IArticleConfigProfile
    {
        void Initialize(Assembly configAssembly, MasterData configRoleData, DetailData configCodeData, IArticleConfigFactory configFactory);
        IList<KeyValuePair<ConfigCode, Int32>> ModelPath();
        ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals);
        ConfigType GetConfigType(ConfigCode configCode);
        IEnumerable<ConfigCode> GetConfigModelResolve(ConfigCode configCode);
    }
}
