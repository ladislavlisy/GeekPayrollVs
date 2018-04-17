using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigRoleSpec = UInt16;
    using ConfigRoleName = String;
    using ConfigRoleItem = Matrixus.IArticleMethod;
    using ConfigRoleData = Interfaces.Permadom.ArticleRoleConfigData;

    using ConfigCodeSpec = UInt16;
    using ConfigCodeType = UInt16;
    using ConfigCodeName = String;
    using ConfigCodeItem = Matrixus.IArticleTarget;
    using ConfigCodeData = Interfaces.Permadom.ArticleCodeConfigData;
    using System.Reflection;

    public interface IArticleConfigFactory
    {
        ConfigRoleItem CreateMethodItem(Assembly configAssembly, ConfigRoleSpec symbolCode, ConfigRoleName symbolName, params ConfigRoleSpec[] symbolPath);
        ConfigCodeItem CreateTargetItem(Assembly configAssembly, ConfigCodeSpec symbolCode, ConfigCodeName symbolName, ConfigRoleSpec symbolRole, ConfigCodeType symbolType, params ConfigCodeSpec[] symbolPath);
    }
}
