using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Permadom
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRoleData = UInt16;
    using ConfigRoleName = String;

    using ConfigItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using Module.Interfaces.Permadom;
    using Module.Codes;


    public class ArticleRoleConfigBuilder
    {
        public static ConfigItem CreateConfigData(ConfigRoleEnum roleEnum, params ConfigRoleEnum[] pathEnum)
        {
            ConfigRoleData roleData = (ConfigRoleData)roleEnum;
            ConfigRoleData[] rolePath = pathEnum.Select((c) => ((ConfigRoleData)c)).ToArray();
            ConfigRoleName roleName = roleEnum.GetSymbol();

            return new ArticleRoleConfigData(roleData, roleName, rolePath);
        }
        public static IEnumerable<ConfigItem> GetConfigDataList()
        {
            IList<ConfigItem> configList = new List<ConfigItem>()
            {
                CreateConfigData(ConfigRoleEnum.ARTROLE_UNKNOWN),
                CreateConfigData(ConfigRoleEnum.ARTROLE_CONTRACT_TERM),
                CreateConfigData(ConfigRoleEnum.ARTROLE_POSITION_TERM),
                CreateConfigData(ConfigRoleEnum.ARTROLE_POSITION_SCHEDULE),
                CreateConfigData(ConfigRoleEnum.ARTROLE_POSITION_TIMESHEET),
                CreateConfigData(ConfigRoleEnum.ARTROLE_POSITION_WORKING),
                CreateConfigData(ConfigRoleEnum.ARTROLE_POSITION_ABSENCE),
                CreateConfigData(ConfigRoleEnum.ARTROLE_CONTRACT_TIMESHEET),
                CreateConfigData(ConfigRoleEnum.ARTROLE_CONTRACT_WORKING),
                CreateConfigData(ConfigRoleEnum.ARTROLE_CONTRACT_ABSENCE),
            };
            return configList;
        }

    }
}
