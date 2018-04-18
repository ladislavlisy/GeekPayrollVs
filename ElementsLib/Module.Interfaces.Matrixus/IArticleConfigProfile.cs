﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using TargetItem = Elements.IArticleTarget;

    using CodeList = IEnumerable<Permadom.ArticleCodeConfigData>;
    using RoleList = IEnumerable<Permadom.ArticleRoleConfigData>;

    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourceErrs = String;

    using Elements;
    using System.Reflection;

    public interface IArticleConfigProfile
    {
        void Initialize(Assembly configAssembly, RoleList configRoleData, CodeList configCodeData, IArticleConfigFactory configFactory);
        IEnumerable<TargetItem> GetTargets(IEnumerable<TargetItem> targetsInit, ConfigCode headCode, ConfigCode partCode);
        IList<KeyValuePair<ConfigCode, Int32>> ModelPath();
        ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals);
    }
}