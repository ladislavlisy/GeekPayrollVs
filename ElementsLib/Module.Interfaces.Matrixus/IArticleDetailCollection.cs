﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigType = UInt16;

    using ConfigItem = Module.Interfaces.Matrixus.IArticleConfigDetail;
    using ConfigData = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourceErrs = String;

    public interface IArticleDetailCollection : IConfigCollection<ConfigItem, ConfigCode>
    {
        void LoadConfigData(IArticleMasterCollection masterStore, IEnumerable<ConfigData> configList, IArticleConfigFactory configFactory);
        ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals);
        ConfigType GetConfigType(ConfigCode configCode);
        IEnumerable<ConfigCode> GetConfigModelResolve(ConfigCode configCode);
    }
}
