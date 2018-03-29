using System;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using ConfigItem = Module.Interfaces.IArticleConfig;
    using ConfigPair = KeyValuePair<UInt16, Module.Interfaces.IArticleConfig>;

    using SymbolCode = Module.Codes.ArticleCzCode;
    using SymbolRole = Module.Codes.ArticleCzRole;

    using Module.Interfaces;
    using Module.Codes;
    using Module.Json;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        public IEnumerable<ConfigPair> CreateConfigList()
        {
            IList<ConfigPair> configList = new List<ConfigPair>()
            {
                CreateConfigPair(SymbolCode.ARTCODE_UNKNOWN, SymbolRole.ARTROLE_UNKNOWN),
                CreateConfigPair(SymbolCode.ARTCODE_CONTRACT_TERM, SymbolRole.ARTROLE_CONTRACT_TERM),
                CreateConfigPair(SymbolCode.ARTCODE_POSITION_TERM, SymbolRole.ARTROLE_POSITION_TERM,
                    SymbolCode.ARTCODE_CONTRACT_TERM),
                CreateConfigPair(SymbolCode.ARTCODE_POSITION_SCHEDULE, SymbolRole.ARTROLE_POSITION_SCHEDULE,
                    SymbolCode.ARTCODE_POSITION_TERM),
                CreateConfigPair(SymbolCode.ARTCODE_POSITION_TIMESHEET, SymbolRole.ARTROLE_POSITION_TIMESHEET,
                    SymbolCode.ARTCODE_POSITION_SCHEDULE),
                CreateConfigPair(SymbolCode.ARTCODE_POSITION_WORKING, SymbolRole.ARTROLE_POSITION_WORKING,
                    SymbolCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(SymbolCode.ARTCODE_POSITION_ABSENCE, SymbolRole.ARTROLE_POSITION_ABSENCE,
                    SymbolCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(SymbolCode.ARTCODE_CONTRACT_TIMESHEET, SymbolRole.ARTROLE_CONTRACT_TIMESHEET,
                    SymbolCode.ARTCODE_CONTRACT_TERM, SymbolCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(SymbolCode.ARTCODE_CONTRACT_WORKING, SymbolRole.ARTROLE_CONTRACT_WORKING,
                    SymbolCode.ARTCODE_CONTRACT_TIMESHEET, SymbolCode.ARTCODE_POSITION_WORKING),
                CreateConfigPair(SymbolCode.ARTCODE_CONTRACT_ABSENCE, SymbolRole.ARTROLE_CONTRACT_ABSENCE,
                    SymbolCode.ARTCODE_CONTRACT_TIMESHEET, SymbolCode.ARTCODE_POSITION_ABSENCE),
            };
            return configList;
        }
        public ConfigItem CreateConfigItem(ArticleConfigNameJson configJson)
        {
            ConfigCode code = ArticleCodeAdapter.CreateCode(configJson.Code);

            ConfigRole role = ArticleRoleAdapter.CreateCode(configJson.Role);

            ConfigCode[] path = configJson.ResolvePath.Select((p) => (ArticleCodeAdapter.CreateCode(p))).ToArray();

            ArticleConfig config = new ArticleConfig(code, role, path);

            return config;
        }
        public ConfigCode CreateConfigCode(ArticleConfigNameJson configJson)
        {
            ConfigCode code = ArticleCodeAdapter.CreateCode(configJson.Code);

            return code;
        }

        protected ConfigPair CreateConfigPair(SymbolCode extCode, SymbolRole extRole, params SymbolCode[] extPath)
        {
            ConfigCode code = (ConfigCode)extCode;

            ConfigRole role = (ConfigRole)extRole;

            ConfigCode[] path = extPath.Select((p) => ((ConfigCode)p)).ToArray();

            return new ConfigPair(code, new ArticleConfig(code, role, path)); 
        }
    }
}
