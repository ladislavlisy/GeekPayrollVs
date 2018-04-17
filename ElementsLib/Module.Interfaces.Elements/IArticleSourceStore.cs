using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigItem = IArticleCodeConfig;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleHolder, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using Matrixus;

    public interface IArticleSourceStore : IEnumerable<KeyValuePair<IArticleHolder, SourcePack>>
    {
        IEnumerable<HolderItem> GetHolders();
        IEnumerable<SourcePair> GetModel();
        void CopyModel(IArticleSourceStore source);
        void AddGeneralItems(IEnumerable<HolderItem> targets);

        IList<SourcePair> PrepareEvaluationPath(IArticleCodeCollection configBundler, 
            ConfigCode contractCode, ConfigCode positionCode);
    }
}
