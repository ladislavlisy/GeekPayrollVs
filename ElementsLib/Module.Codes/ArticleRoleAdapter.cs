using System;

namespace ElementsLib.Module.Codes
{
    using ConfigRoleEnum = ArticleRoleCz;
    using EnumRole = UInt16;

    using Libs;

    public class ArticleRoleAdapter
    {
        public static ConfigRoleEnum CreateEnum(EnumRole symbolNumb)
        {
            return symbolNumb.ToEnum<ConfigRoleEnum>(GetDefaultCode());
        }
        public static ConfigRoleEnum CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<ConfigRoleEnum>(GetDefaultCode());
        }
        public static EnumRole CreateCode(EnumRole symbolNumb)
        {
            return (EnumRole)symbolNumb.ToEnum<ConfigRoleEnum>(GetDefaultCode());
        }
        public static EnumRole CreateCode(string symbolName)
        {
            return (EnumRole)symbolName.ToEnum<ConfigRoleEnum>(GetDefaultCode());
        }
        private static ConfigRoleEnum GetDefaultCode()
        {
            return ConfigRoleEnum.ARTROLE_UNKNOWN;
        }
    }
}
