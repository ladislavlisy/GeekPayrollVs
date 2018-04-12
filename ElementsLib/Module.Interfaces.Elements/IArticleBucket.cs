using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigItem = IArticleConfig;

    using TargetPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using Matrixus;

    public interface IArticleBucket : IEnumerable<KeyValuePair<IArticleTarget, SourcePack>>
    {
        IEnumerable<IArticleTarget> GetTargets();
        IEnumerable<KeyValuePair<IArticleTarget, SourcePack>> GetModel();
        void CopyTargets(IArticleBucket source);
        void ComplementTrace(IEnumerable<IArticleTarget> targets);

        IList<TargetPair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler, 
            ConfigCode contractCode, ConfigCode positionCode);
    }
}
