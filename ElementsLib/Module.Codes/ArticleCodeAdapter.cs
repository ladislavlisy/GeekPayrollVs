using System;

namespace ElementsLib.Module.Codes
{
    using ArticleCode = ArticleCzCode;

    using Libs;

    public class ArticleCodeAdapter
    {
        public static ArticleCode CreateContractCode()
        {
            return ArticleCode.ARTCODE_CONTRACT_TERM;
        }
        public static ArticleCode CreatePositionCode()
        {
            return ArticleCode.ARTCODE_POSITION_TERM;
        }
        public static ArticleCode CreateEnum(UInt16 symbolNumb)
        {
            return symbolNumb.ToEnum<ArticleCode>(GetDefaultCode());
        }
        public static ArticleCode CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<ArticleCode>(GetDefaultCode());
        }
        public static UInt16 CreateCode(UInt16 symbolNumb)
        {
            return (UInt16)symbolNumb.ToEnum<ArticleCode>(GetDefaultCode());
        }
        public static UInt16 CreateCode(string symbolName)
        {
            return (UInt16)symbolName.ToEnum<ArticleCode>(GetDefaultCode());
        }
        private static ArticleCode GetDefaultCode()
        {
            return ArticleCode.ARTCODE_UNKNOWN;
        }
    }
}
