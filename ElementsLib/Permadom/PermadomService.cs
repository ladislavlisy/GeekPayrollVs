using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Permadom
{
    using ArticleCodeConfigItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using ArticleRoleConfigItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using Module.Interfaces.Permadom;

    public class PermadomService : IPermadomService
    {
        public IEnumerable<ArticleCodeConfigItem> GetArticleCodeDataList()
        {
            return new List<ArticleCodeConfigItem>()
            {
                new ArticleCodeConfigData(0, 0, 0, "FACT_UNKNOWN"),
                new ArticleCodeConfigData(1, 1, 0, "FACT_CONTRACT_TERM"),
                new ArticleCodeConfigData(2, 2, 1, "FACT_POSITION_TERM", 1),
                new ArticleCodeConfigData(3, 3, 2, "FACT_POSITION_SCHEDULE", 2),
                new ArticleCodeConfigData(4, 4, 2, "FACT_POSITION_TIMESHEET", 3),
                new ArticleCodeConfigData(5, 5, 2, "FACT_POSITION_WORKING", 4),
                new ArticleCodeConfigData(6, 6, 2, "FACT_POSITION_ABSENCE", 4),
                new ArticleCodeConfigData(7, 7, 1, "FACT_CONTRACT_TIMESHEET", 1, 4),
                new ArticleCodeConfigData(8, 8, 1, "FACT_CONTRACT_WORKING", 7, 5),
                new ArticleCodeConfigData(9, 9, 1, "FACT_CONTRACT_ABSENCE", 7, 6),
            };
        }
        public IEnumerable<ArticleRoleConfigItem> GetArticleRoleDataList()
        {
            return new List<ArticleRoleConfigItem>()
            {
                new ArticleRoleConfigData(0, "ARTICLE_UNKNOWN"),
                new ArticleRoleConfigData(1, "ARTICLE_CONTRACT_TERM"),
                new ArticleRoleConfigData(2, "ARTICLE_POSITION_TERM"),
                new ArticleRoleConfigData(3, "ARTICLE_POSITION_SCHEDULE"),
                new ArticleRoleConfigData(4, "ARTICLE_POSITION_TIMESHEET"),
                new ArticleRoleConfigData(5, "ARTICLE_POSITION_WORKING"),
                new ArticleRoleConfigData(6, "ARTICLE_POSITION_ABSENCE"),
                new ArticleRoleConfigData(7, "ARTICLE_CONTRACT_TIMESHEET"),
                new ArticleRoleConfigData(8, "ARTICLE_CONTRACT_WORKING"),
                new ArticleRoleConfigData(9, "ARTICLE_CONTRACT_ABSENCE"),
            };
        }

        public IEnumerable<ArticleCodeConfigItem> CreateArticleCodeDataList()
        {
            return ArticleCodeConfigBuilder.GetConfigDataList();
        }
        public IEnumerable<ArticleRoleConfigItem> CreateArticleRoleDataList()
        {
            return ArticleRoleConfigBuilder.GetConfigDataList();
        }
    }
}
