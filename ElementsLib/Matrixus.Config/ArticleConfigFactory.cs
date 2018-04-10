using System;
using System.Linq;
using System.Collections.Generic;

namespace ElementsLib.Matrixus.Config
{
    using BodyCode = UInt16;
    using BodyRole = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleConfig;
    using BodyPair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleConfig>;

    using MarkCode = Module.Codes.ArticleCzCode;
    using MarkRole = Module.Codes.ArticleCzRole;

    using Module.Interfaces.Elements;
    using Module.Codes;
    using Module.Json;

    public class ArticleConfigFactory : IArticleConfigFactory
    {
        public IEnumerable<BodyPair> CreateConfigList()
        {
            IList<BodyPair> configList = new List<BodyPair>()
            {
                CreateConfigPair(MarkCode.ARTCODE_UNKNOWN, MarkRole.ARTROLE_UNKNOWN),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_TERM, MarkRole.ARTROLE_CONTRACT_TERM),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_TERM, MarkRole.ARTROLE_POSITION_TERM,
                    MarkCode.ARTCODE_CONTRACT_TERM),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_SCHEDULE, MarkRole.ARTROLE_POSITION_SCHEDULE,
                    MarkCode.ARTCODE_POSITION_TERM),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_TIMESHEET, MarkRole.ARTROLE_POSITION_TIMESHEET,
                    MarkCode.ARTCODE_POSITION_SCHEDULE),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_WORKING, MarkRole.ARTROLE_POSITION_WORKING,
                    MarkCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(MarkCode.ARTCODE_POSITION_ABSENCE, MarkRole.ARTROLE_POSITION_ABSENCE,
                    MarkCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_TIMESHEET, MarkRole.ARTROLE_CONTRACT_TIMESHEET,
                    MarkCode.ARTCODE_CONTRACT_TERM, MarkCode.ARTCODE_POSITION_TIMESHEET),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_WORKING, MarkRole.ARTROLE_CONTRACT_WORKING,
                    MarkCode.ARTCODE_CONTRACT_TIMESHEET, MarkCode.ARTCODE_POSITION_WORKING),
                CreateConfigPair(MarkCode.ARTCODE_CONTRACT_ABSENCE, MarkRole.ARTROLE_CONTRACT_ABSENCE,
                    MarkCode.ARTCODE_CONTRACT_TIMESHEET, MarkCode.ARTCODE_POSITION_ABSENCE),
            };
            return configList;
        }
        public BodyItem CreateConfigItem(ArticleConfigNameJson configJson)
        {
            BodyCode code = ArticleCodeAdapter.CreateCode(configJson.Code);

            BodyRole role = ArticleRoleAdapter.CreateCode(configJson.Role);

            BodyCode[] path = configJson.ResolvePath.Select((p) => (ArticleCodeAdapter.CreateCode(p))).ToArray();

            ArticleConfig config = new ArticleConfig(code, role, path);

            return config;
        }
        public BodyCode CreateConfigCode(ArticleConfigNameJson configJson)
        {
            BodyCode code = ArticleCodeAdapter.CreateCode(configJson.Code);

            return code;
        }

        protected BodyPair CreateConfigPair(MarkCode extCode, MarkRole extRole, params MarkCode[] extPath)
        {
            BodyCode code = (BodyCode)extCode;

            BodyRole role = (BodyRole)extRole;

            BodyCode[] path = extPath.Select((p) => ((BodyCode)p)).ToArray();

            return new BodyPair(code, new ArticleConfig(code, role, path)); 
        }
    }
}
