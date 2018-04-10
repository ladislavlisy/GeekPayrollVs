using System;

namespace ElementsLib.Module.Codes
{
    using MarkCode = ArticleCzCode;
    using EnumCode = UInt16;

    using Libs;

    public class ArticleCodeAdapter
    {
        public static MarkCode CreateContractCode()
        {
            return MarkCode.ARTCODE_CONTRACT_TERM;
        }
        public static MarkCode CreatePositionCode()
        {
            return MarkCode.ARTCODE_POSITION_TERM;
        }
        public static MarkCode CreateEnum(EnumCode symbolNumb)
        {
            return symbolNumb.ToEnum<MarkCode>(GetDefaultCode());
        }
        public static MarkCode CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<MarkCode>(GetDefaultCode());
        }
        public static EnumCode CreateCode(EnumCode symbolNumb)
        {
            return (EnumCode)symbolNumb.ToEnum<MarkCode>(GetDefaultCode());
        }
        public static EnumCode CreateCode(string symbolName)
        {
            return (EnumCode)symbolName.ToEnum<MarkCode>(GetDefaultCode());
        }
        private static MarkCode GetDefaultCode()
        {
            return MarkCode.ARTCODE_UNKNOWN;
        }
    }
}
