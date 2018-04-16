using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Permadom
{
    using Module.Codes;

    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCodeData = UInt16;
    using ConfigCodeName = String;
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRoleData = UInt16;
    using ConfigTypeEnum = Module.Codes.ArticleType;
    using ConfigTypeData = UInt16;

    using ConfigItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    public class ArticleCodeConfigBuilder
    {
        public static ConfigItem CreateConfigItem(ConfigCodeEnum codeEnum, ConfigRoleEnum roleEnum, ConfigTypeEnum typeEnum, params ConfigCodeEnum[] pathEnum)
        {
            ConfigCodeData codeData = (ConfigCodeData)codeEnum;
            ConfigRoleData roleData = (ConfigRoleData)roleEnum;
            ConfigTypeData typeData = (ConfigTypeData)typeEnum;
            ConfigCodeData[] codePath = pathEnum.Select((c) => ((ConfigCodeData)c)).ToArray();
            ConfigCodeName codeName = codeEnum.GetSymbol();

            return new ConfigItem(codeData, roleData, typeData, codeName, codePath);
        }
        public static IEnumerable<ConfigItem> GetConfigDataList()
        {
            IList<ConfigItem> configList = new List<ConfigItem>()
            {
                CreateConfigItem(ConfigCodeEnum.ARTCODE_UNKNOWN, ConfigRoleEnum.ARTROLE_UNKNOWN, ArticleType.NO_HEAD_PART_TYPE),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_CONTRACT_TERM, ConfigRoleEnum.ARTROLE_CONTRACT_TERM, ArticleType.NO_HEAD_PART_TYPE),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_POSITION_TERM, ConfigRoleEnum.ARTROLE_POSITION_TERM, ArticleType.HEAD_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_CONTRACT_TERM),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_POSITION_SCHEDULE, ConfigRoleEnum.ARTROLE_POSITION_SCHEDULE, ArticleType.PART_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_POSITION_TERM),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_POSITION_TIMESHEET, ConfigRoleEnum.ARTROLE_POSITION_TIMESHEET, ArticleType.PART_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_POSITION_SCHEDULE),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_POSITION_WORKING, ConfigRoleEnum.ARTROLE_POSITION_WORKING, ArticleType.PART_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_POSITION_TIMESHEET),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_POSITION_ABSENCE, ConfigRoleEnum.ARTROLE_POSITION_ABSENCE, ArticleType.PART_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_POSITION_TIMESHEET),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_CONTRACT_TIMESHEET, ConfigRoleEnum.ARTROLE_CONTRACT_TIMESHEET, ArticleType.HEAD_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_CONTRACT_TERM, ConfigCodeEnum.ARTCODE_POSITION_TIMESHEET),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_CONTRACT_WORKING, ConfigRoleEnum.ARTROLE_CONTRACT_WORKING, ArticleType.HEAD_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_CONTRACT_TIMESHEET, ConfigCodeEnum.ARTCODE_POSITION_WORKING),
                CreateConfigItem(ConfigCodeEnum.ARTCODE_CONTRACT_ABSENCE, ConfigRoleEnum.ARTROLE_CONTRACT_ABSENCE, ArticleType.HEAD_CODE_ARTICLE,
                    ConfigCodeEnum.ARTCODE_CONTRACT_TIMESHEET, ConfigCodeEnum.ARTCODE_POSITION_ABSENCE),
            };
            return configList;
        }
    }
}
