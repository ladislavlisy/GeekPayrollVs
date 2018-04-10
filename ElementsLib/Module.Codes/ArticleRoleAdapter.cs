using System;

namespace ElementsLib.Module.Codes
{
    using MarkRole = ArticleCzRole;
    using EnumRole = UInt16;

    using Libs;

    public class ArticleRoleAdapter
    {
        public static MarkRole CreateEnum(EnumRole symbolNumb)
        {
            return symbolNumb.ToEnum<MarkRole>(GetDefaultCode());
        }
        public static MarkRole CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<MarkRole>(GetDefaultCode());
        }
        public static EnumRole CreateCode(EnumRole symbolNumb)
        {
            return (EnumRole)symbolNumb.ToEnum<MarkRole>(GetDefaultCode());
        }
        public static EnumRole CreateCode(string symbolName)
        {
            return (EnumRole)symbolName.ToEnum<MarkRole>(GetDefaultCode());
        }
        private static MarkRole GetDefaultCode()
        {
            return MarkRole.ARTROLE_UNKNOWN;
        }
    }
}
