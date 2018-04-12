using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigItem = IArticleConfig;

    using TargetPair = KeyValuePair<IArticleTarget, IArticleSource>;
    using SortedPair = KeyValuePair<UInt16, Int32>;

    using Matrixus;

    public interface IArticleBucket : IEnumerable<KeyValuePair<IArticleTarget, IArticleSource>>
    {
        IEnumerable<IArticleTarget> GetTargets();
        IEnumerable<KeyValuePair<IArticleTarget, IArticleSource>> GetModel();
        void CopyTargets(IArticleBucket source);
        void ComplementTrace(IEnumerable<IArticleTarget> targets);

        IList<TargetPair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler, 
            ConfigCode contractCode, ConfigCode positionCode);
    }
}
