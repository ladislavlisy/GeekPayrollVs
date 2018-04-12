using System;
    using System.Collections.Generic;
    using System.Linq;

namespace ElementsLib.Module.Codes
{
    using MarkCode = ArticleCzCode;
    using EnumCode = UInt16;
    using MarkRole = ArticleCzRole;
    using EnumRole = UInt16;

    using BodyType = UInt16;
    using BodyItem = Interfaces.Elements.IArticleConfig;
    using BodyPair = KeyValuePair<UInt16, Interfaces.Elements.IArticleConfig>;

    using Libs;
    using Matrixus.Config;

    public class ArticleCodeAdapter
    {
        const BodyType NO_HEAD_PART_TYPE = 0;

        const BodyType HEAD_CODE_ARTICLE = 1;
        const BodyType PART_CODE_ARTICLE = 2;

        public static MarkCode GetContractEnum()
        {
            return MarkCode.ARTCODE_CONTRACT_TERM;
        }
        public static MarkCode GetPositionEnum()
        {
            return MarkCode.ARTCODE_POSITION_TERM;
        }
        public static MarkCode GetDefaultsEnum()
        {
            return MarkCode.ARTCODE_UNKNOWN;
        }
        public static EnumCode GetContractCode()
        {
            return (EnumCode)MarkCode.ARTCODE_CONTRACT_TERM;
        }
        public static EnumCode GetPositionCode()
        {
            return (EnumCode)MarkCode.ARTCODE_POSITION_TERM;
        }
        public static EnumCode GetDefaultsCode()
        {
            return (EnumCode)MarkCode.ARTCODE_UNKNOWN;
        }
        public static MarkCode CreateEnum(EnumCode symbolNumb)
        {
            return symbolNumb.ToEnum<MarkCode>(GetDefaultsEnum());
        }
        public static MarkCode CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<MarkCode>(GetDefaultsEnum());
        }
        public static EnumCode CreateCode(EnumCode symbolNumb)
        {
            return (EnumCode)symbolNumb.ToEnum<MarkCode>(GetDefaultsEnum());
        }
        public static EnumCode CreateCode(string symbolName)
        {
            return (EnumCode)symbolName.ToEnum<MarkCode>(GetDefaultsEnum());
        }
        public static IEnumerable<EnumCode> GetSelectedCodes()
        {
            IEnumerable<MarkCode> symbolList = EnumUtilsExtensions.GetSelectedItems<MarkCode>().ToList();

            IEnumerable<EnumCode> configList = symbolList.Select((c) => ((EnumCode)c)).ToList();

            return configList;
        }

        public static IEnumerable<BodyPair> GetConfigurationList()
        {
            IList<BodyPair> configList = new List<BodyPair>()
            {
                CreateConfigPair(MarkCode.ARTCODE_UNKNOWN, MarkRole.ARTROLE_UNKNOWN, NO_HEAD_PART_TYPE),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_TERM, MarkRole.ARTROLE_CONTRACT_TERM, NO_HEAD_PART_TYPE),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_TERM, MarkRole.ARTROLE_POSITION_TERM, HEAD_CODE_ARTICLE,
                    MarkCode.ARTCODE_CONTRACT_TERM),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_SCHEDULE, MarkRole.ARTROLE_POSITION_SCHEDULE, PART_CODE_ARTICLE,
                    MarkCode.ARTCODE_POSITION_TERM),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_TIMESHEET, MarkRole.ARTROLE_POSITION_TIMESHEET, PART_CODE_ARTICLE,
                    MarkCode.ARTCODE_POSITION_SCHEDULE),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_WORKING, MarkRole.ARTROLE_POSITION_WORKING, PART_CODE_ARTICLE,
                    MarkCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_ABSENCE, MarkRole.ARTROLE_POSITION_ABSENCE, PART_CODE_ARTICLE,
                    MarkCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_TIMESHEET, MarkRole.ARTROLE_CONTRACT_TIMESHEET, HEAD_CODE_ARTICLE,
                    MarkCode.ARTCODE_CONTRACT_TERM, MarkCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_WORKING, MarkRole.ARTROLE_CONTRACT_WORKING, HEAD_CODE_ARTICLE,
                    MarkCode.ARTCODE_CONTRACT_TIMESHEET, MarkCode.ARTCODE_POSITION_WORKING),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_ABSENCE, MarkRole.ARTROLE_CONTRACT_ABSENCE, HEAD_CODE_ARTICLE,
                    MarkCode.ARTCODE_CONTRACT_TIMESHEET, MarkCode.ARTCODE_POSITION_ABSENCE),
            };
            return configList;
        }
        protected static BodyItem CreateConfigItem(EnumCode extCode, EnumRole extRole, BodyType exType, params EnumCode[] extPath)
        {
            EnumCode code = (EnumCode)extCode;

            EnumRole role = (EnumRole)extRole;

            EnumCode[] path = extPath.Select((p) => ((EnumCode)p)).ToArray();

            BodyItem config = new ArticleConfig(code, role, exType, path);

            return config;
        }
        protected static BodyPair CreateConfigPair(MarkCode extCode, MarkRole extRole, BodyType exType, params MarkCode[] extPath)
        {
            EnumCode code = (EnumCode)extCode;

            EnumRole role = (EnumRole)extRole;

            EnumCode[] path = extPath.Select((p) => ((EnumCode)p)).ToArray();

            return new BodyPair(code, CreateConfigItem(code, role, exType, path));
        }

        public static IEnumerable<EnumCode> GetAllCodes()
        {
            IEnumerable<MarkCode> symbolList = EnumUtilsExtensions.GetAllItems<MarkCode>().ToList();

            IEnumerable<EnumCode> configList = symbolList.Select((c) => ((EnumCode)c)).ToList();

            return configList;
        }

        public static string GetSymbol(EnumCode symbolNumb)
        {
            MarkCode symbol = CreateEnum(symbolNumb);

            return symbol.GetSymbol();
        }

    }
}
