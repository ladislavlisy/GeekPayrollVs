using System;

namespace ElementsLib.Matrixus.Config
{
    using ConfigRoleSpec = UInt16;
    using ConfigRoleName = String;
    using ConfigRoleItem = Module.Interfaces.Matrixus.IArticleMethod;
    using ConfigRoleData = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using ConfigCodeSpec = UInt16;
    using ConfigCodeType = UInt16;
    using ConfigCodeName = String;
    using ConfigCodeItem = Module.Interfaces.Matrixus.IArticleTarget;
    using ConfigCodeData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using Module.Interfaces.Elements;
    using System.Reflection;
    using Module.Codes;
    using Module.Common;
    using System.Text.RegularExpressions;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        private const string ROLE_NAME_CLASS_POSTFIX = "Method";
        private const string ROLE_NAME_CLASS_PATTERN = "METHOD_(.*)";
        private const string ROLE_NAME_SPACE_PATTERN = "ElementsLib.Elements.Config.Methods";
        private const string ROLE_NAME_CLASS_DEFAULT = "METHOD_UNKNOWN";

        private const string CODE_NAME_CLASS_POSTFIX = "Target";
        private const string CODE_NAME_CLASS_PATTERN = "TARGET_(.*)";
        private const string CODE_NAME_SPACE_PATTERN = "ElementsLib.Elements.Config.Targets";
        private const string CODE_NAME_CLASS_DEFAULT = "TARGET_UNKNOWN";

        public ConfigRoleItem CreateMethodItem(Assembly configAssembly, ConfigRoleSpec symbolCode, ConfigRoleName symbolName, params ConfigRoleSpec[] symbolPath)
        {
            string symbolClass = CreateMethodName(symbolName);

            string backupClass = CreateMethodName(ROLE_NAME_CLASS_DEFAULT);

            ConfigRoleItem elementItem = GeneralClazzFactory<ConfigRoleItem>.InstanceFor(configAssembly, ROLE_NAME_SPACE_PATTERN, symbolClass, backupClass);

            elementItem.SetSymbolRole(symbolCode, symbolPath);

            return elementItem;
        }

        protected ConfigRoleName CreateMethodName(ConfigRoleName symbolName)
        {
            string symbolClass = GeneralNamesFactory.ClassNameFor(ROLE_NAME_CLASS_POSTFIX, ROLE_NAME_CLASS_PATTERN, symbolName);

            return symbolClass;
        }
        public ConfigCodeItem CreateTargetItem(Assembly configAssembly, ConfigCodeSpec symbolCode, ConfigCodeName symbolName, ConfigRoleSpec symbolRole, ConfigCodeType symbolType, params ConfigCodeSpec[] symbolPath)
        {
            string symbolClass = CreateSourceName(symbolName);

            string backupClass = CreateSourceName(CODE_NAME_CLASS_DEFAULT);

            ConfigCodeItem elementItem = GeneralClazzFactory<ConfigCodeItem>.InstanceFor(configAssembly, CODE_NAME_SPACE_PATTERN, symbolClass, backupClass);

            elementItem.SetSymbolCode(symbolCode, symbolType, symbolPath);

            return elementItem;
        }

        protected ConfigCodeName CreateSourceName(ConfigCodeName symbolName)
        {
            string symbolClass = GeneralNamesFactory.ClassNameFor(CODE_NAME_CLASS_POSTFIX, CODE_NAME_CLASS_PATTERN, symbolName);

            return symbolClass;
        }
    }
}
