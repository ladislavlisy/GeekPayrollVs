using System;
using System.Collections.Generic;

namespace ElementsLib.Service.Permadom
{
    using ArticleCodeConfigItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using ArticleRoleConfigItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using Module.Codes;
    using Module.Interfaces.Permadom;
    using ElementsLib.Elements.Config.Sources;
    using ElementsLib.Legalist.Constants;

    public class SimplePermadomService : IPermadomService
    {
        public IEnumerable<ArticleData> GetArticleSourceData()
        {
            return new List<ArticleData>()
            {
                new ArticleData() {
                    Head = 0, Part = 0, Seed = 1, Code = (UInt16)ArticleCodeCz.FACT_CONTRACT_TERM,
                    Tags = new ContractTermSource(TestModule.DateFrom, TestModule.DateStop, TestModule.EmployeeTerm),
                },
                new ArticleData() {
                    Head = 1, Part = 0, Seed = 1, Code = (UInt16)ArticleCodeCz.FACT_POSITION_TERM,
                    Tags = new PositionTermSource(TestModule.DateFrom, TestModule.DateStop, TestModule.PositionTerm),
                },
                new ArticleData() {
                    Head = 1, Part = 1, Seed = 1, Code = (UInt16)ArticleCodeCz.FACT_POSITION_SCHEDULE,
                    Tags = new PositionScheduleSource(TestModule.ShiftLiable, TestModule.ShiftActual, TestModule.ScheduleType),
                },
                new ArticleData() {
                    Head = 1, Part = 0, Seed = 1, Code = (UInt16)ArticleCodeCz.FACT_CONTRACT_WORKING,
                    Tags = null,
                },
                //FACT_POSITION_TIMESHEET,
                //FACT_POSITION_WORKING,
                //FACT_POSITION_ABSENCE,
                //FACT_CONTRACT_TIMESHEET,
                //FACT_CONTRACT_WORKING,
                //FACT_CONTRACT_ABSENCE,
            };
        }
        public IEnumerable<ArticleCodeConfigItem> GetArticleCodeData()
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
        public IEnumerable<ArticleRoleConfigItem> GetArticleRoleData()
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
    static class TestModule
    {
        #region TEST_VALUES

        public static DateTime? DateFrom = new DateTime(2010, 1, 1);
        public static DateTime? DateStop = null;
        public static WorkEmployTerms EmployeeTerm = WorkEmployTerms.WORKTERM_EMPLOYMENT_1;
        public static WorkPositionType PositionTerm = WorkPositionType.POSITION_EXCLUSIVE;
        public static Int32 ShiftLiable = 144000;
        public static Int32 ShiftActual = 144000;
        public static WorkScheduleType ScheduleType = WorkScheduleType.SCHEDULE_NORMALY_WEEK;

        #endregion
    }
}
