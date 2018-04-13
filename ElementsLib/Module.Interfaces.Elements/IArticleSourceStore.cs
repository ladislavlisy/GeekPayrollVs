using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigItem = IArticleConfig;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using Matrixus;

    public interface IArticleSourceStore : IEnumerable<KeyValuePair<IArticleTarget, SourcePack>>
    {
        IEnumerable<TargetItem> GetTargets();
        IEnumerable<SourcePair> GetModel();
        void CopyModel(IArticleSourceStore source);
        void AddGeneralItems(IEnumerable<TargetItem> targets);

        IList<SourcePair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler, 
            ConfigCode contractCode, ConfigCode positionCode);
    }
}
