using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using Elements;

    public interface IConfigCollection<TConfig, TIndex>
    {
        TConfig FindArticleConfig(TIndex modelCode);
        void InitConfigModel(IArticleConfigFactory configFactory);
        IEnumerable<IArticleTarget> GetTargets(IEnumerable<IArticleTarget> targetsInit, TIndex headCode, TIndex partCode);
        IList<KeyValuePair<TIndex, Int32>> ModelPath();
    }
}