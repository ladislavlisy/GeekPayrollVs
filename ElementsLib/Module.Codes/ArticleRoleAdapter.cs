using System;

namespace ElementsLib.Module.Codes
{
    using ArticleRole = ArticleCzRole;

    using Libs;

    public class ArticleRoleAdapter
    {
        public static ArticleRole CreateEnum(UInt16 symbolNumb)
        {
            return symbolNumb.ToEnum<ArticleRole>(GetDefaultCode());
        }
        public static ArticleRole CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<ArticleRole>(GetDefaultCode());
        }
        public static UInt16 CreateCode(UInt16 symbolNumb)
        {
            return (UInt16)symbolNumb.ToEnum<ArticleRole>(GetDefaultCode());
        }
        public static UInt16 CreateCode(string symbolName)
        {
            return (UInt16)symbolName.ToEnum<ArticleRole>(GetDefaultCode());
        }
        private static ArticleRole GetDefaultCode()
        {
            return ArticleRole.ARTROLE_UNKNOWN;
        }
    }
}
