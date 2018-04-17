using System;

namespace ElementsLib.Matrixus.Config
{
    using ConfigRoleSpec = UInt16;
    using ConfigRoleName = String;
    using ConfigRoleItem = Module.Interfaces.Elements.IArticleRoleConfig;
    using ConfigRoleData = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using ConfigCodeSpec = UInt16;
    using ConfigCodeName = String;
    using ConfigCodeItem = Module.Interfaces.Elements.IArticleCodeConfig;
    using ConfigCodeData = Module.Interfaces.Permadom.ArticleCodeConfigData;

    using Module.Interfaces.Elements;
    using System.Reflection;
    using Module.Codes;
    using Module.Common;
    using System.Text.RegularExpressions;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        private const string CODE_NAME_CLASS_POSTFIX = "Method";
        private const string CODE_NAME_CLASS_PATTERN = "METHOD_(.*)";
        private const string CODE_NAME_SPACE_PATTERN = "ElementsLib.Elements.Methods";

        private const string ROLE_NAME_CLASS_POSTFIX = "Target";
        private const string ROLE_NAME_CLASS_PATTERN = "TARGET_(.*)";
        private const string ROLE_NAME_SPACE_PATTERN = "ElementsLib.Elements.Targets";

        public ConfigRoleItem CreateConfigRoleItem(ConfigRoleData codeData)
        {
            ArticleRoleConfig config = new ArticleRoleConfig(codeData.Role, codeData.Name, codeData.Path);

            return config;
        }
        public ConfigCodeItem CreateConfigCodeItem(ConfigCodeData codeData)
        {
            ArticleCodeConfig config = new ArticleCodeConfig(codeData.Code, codeData.Role, codeData.Type, codeData.Name, codeData.Path);

            return config;
        }

        public ConfigRoleItem CreateMethodItem(Assembly configAssembly, ConfigRoleSpec symbolCode, ConfigRoleSpec backupCode)
        {
            string symbolClass = CreateMethodName(symbolCode);

            string backupClass = CreateMethodName(backupCode);

            ConfigRoleItem sourceItem = GeneralClazzFactory<ConfigRoleItem>.InstanceFor(configAssembly, ROLE_NAME_SPACE_PATTERN, symbolClass, backupClass);

            return sourceItem;
        }

        protected ConfigRoleName CreateMethodName(ConfigRoleSpec symbolCode)
        {
            string symbolClazz = ArticleRoleAdapter.CreateEnum(symbolCode).GetSymbol();

            string symbolClass = GeneralNamesFactory.ClassNameFor(ROLE_NAME_CLASS_POSTFIX, ROLE_NAME_CLASS_PATTERN, symbolClazz);

            return symbolClass;
        }
        public ConfigCodeItem CreateSourceItem(Assembly configAssembly, ConfigCodeSpec symbolCode, ConfigCodeSpec backupCode)
        {
            string symbolClass = CreateSourceName(symbolCode);

            string backupClass = CreateSourceName(backupCode);

            ConfigCodeItem sourceItem = GeneralClazzFactory<ConfigCodeItem>.InstanceFor(configAssembly, CODE_NAME_SPACE_PATTERN, symbolClass, backupClass);

            return sourceItem;
        }

        protected ConfigCodeName CreateSourceName(ConfigCodeSpec symbolCode)
        {
            string symbolClazz = ArticleCodeAdapter.CreateEnum(symbolCode).GetSymbol();

            string symbolClass = GeneralNamesFactory.ClassNameFor(CODE_NAME_CLASS_POSTFIX, CODE_NAME_CLASS_PATTERN, symbolClazz);

            return symbolClass;
        }
    }
}
