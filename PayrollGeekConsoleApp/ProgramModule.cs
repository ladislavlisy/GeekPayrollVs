using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

using ElementsLib;
using ElementsLib.Matrixus.Config;
using ElementsLib.Elements.Config;
using ElementsLib.Elements.Config.Source;
using ElementsLib.Elements.Config.Articles;
using ElementsLib.Elements;
using ElementsLib.Legalist.Constants;
using ElementsLib.Module.Json;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Module.Codes;

namespace PayrollGeekConsoleApp
{
    using ArticleCode = ArticleCzCode;
    using SeasoneCode = UInt16;
    using EpisodeCode = UInt16;
    static class ProgramModule
    {
        public static void CreatePayrollData(string configFolder)
        {
            ArticleSourceCollection payrollSource = new ArticleSourceCollection();

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            payrollSource.InitConfigModel(configAssembly, configFactory);

            var payrollData = new ArticleBucket(payrollSource);

            DateTime? TestDateFrom = new DateTime(2010, 1, 1);
            DateTime? TestDateStop = null;
            var TestEmployeeTerm = WorkEmployTerms.WORKTERM_EMPLOYMENT_1;
            var TestPositionTerm = WorkPositionType.POSITION_EXCLUSIVE;
            Int32 TestShiftLiable = 0;
            Int32 TestShiftActual = 0;
            WorkScheduleType TestScheduleType = WorkScheduleType.SCHEDULE_NORMALY_WEEK;

            ArticleData[] payrollLoad = new ArticleData[]
            {
                new ArticleData() {
                    Service = 0, Episode = 0, Placing = 0, Article = (UInt16)ArticleCzCode.ARTCODE_CONTRACT_TERM,
//                  Service = 0, Episode = 0, Sorting = 0, Article = (UInt16)ArticleCzCode.ARTCODE_CONTRACT_TERM,
                    Records = new ContractTermSource(TestDateFrom, TestDateStop, TestEmployeeTerm),
                },
                new ArticleData() {
                    Service = 0, Episode = 0, Placing = 0, Article = (UInt16)ArticleCzCode.ARTCODE_POSITION_TERM,
                    Records = new PositionTermSource(TestDateFrom, TestDateStop, TestPositionTerm),
                },
                new ArticleData() {
                    Service = 0, Episode = 0, Placing = 0, Article = (UInt16)ArticleCzCode.ARTCODE_POSITION_SCHEDULE,
                    Records = new PositionScheduleSource(TestShiftLiable, TestShiftActual, TestScheduleType),
                },
                //ARTCODE_POSITION_TIMESHEET,
                //ARTCODE_POSITION_WORKING,
                //ARTCODE_POSITION_ABSENCE,
                //ARTCODE_CONTRACT_TIMESHEET,
                //ARTCODE_CONTRACT_WORKING,
                //ARTCODE_CONTRACT_ABSENCE,
            };

            foreach (var data in payrollLoad)
            {
                payrollData.AddGeneralItem(data.Service, data.Episode, data.Article, data.Placing, data.Records);
            }

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_PAYROLL.TXT");

            try
            {
                StreamWriter writerFile = new StreamWriter(configFilePath, false, Encoding.GetEncoding("windows-1250"));

                foreach (var item in payrollData)
                {
                    writerFile.WriteLine(item.ToString());
                }

                writerFile.Flush();

                writerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }

        public static void LoadSourceJson(string configFolder)
        {
            string configContent = "";

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_SOURCE.JSON");

            try
            {
                StreamReader readerFile = new StreamReader(configFilePath, Encoding.GetEncoding("windows-1250"));

                configContent = readerFile.ReadToEnd();

                readerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            var contractSourceConverter = new ArticleJsonConverter<ContractTermArticle>();
            var positionSourceConverter = new ArticleJsonConverter<PositionTermArticle>();

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(contractSourceConverter);
            settings.Converters.Add(positionSourceConverter);

            // var ImportArticleCollection = JsonConvert.DeserializeObject<List<IArticleSource>>(configContent, settings);
        }

        public static void LoadSourceModel()
        {
            ArticleSourceCollection service = new ArticleSourceCollection();

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            service.InitConfigModel(configAssembly, configFactory);

            return;
        }
        public static void LoadConfigModel()
        {
            ArticleConfigCollection service = new ArticleConfigCollection();

            ArticleConfigFactory factory = new ArticleConfigFactory();

            service.InitConfigModel(factory);
        }

        public static void SaveConfigToJson(string configFolder)
        {
            IList<ArticleConfigNameJson> configList = new List<ArticleConfigNameJson>()
            {
                new ArticleConfigNameJson() {
                    Code = "ARTCODE_UNKNOWN", Role = "ARTROLE_UNKNOWN", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "ARTCODE_CONTRACT_TERM", Role = "ARTROLE_CONTRACT_TERM", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "ARTCODE_POSITION_TERM", Role = "ARTROLE_POSITION_TERM", ResolvePath = new string[] { "ARTCODE_CONTRACT_TERM" }
                },
            };

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");
            ConfigJsonReader.SaveJsonData<ArticleConfigNameJson>(configFilePath, configList);
        }
        public static void loadConfigFromJson(string configFolder)
        {
            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");

            IList<ArticleConfigNameJson> configList = ConfigJsonReader.ReadJsonData<ArticleConfigNameJson>(configFilePath);
        }

    }
}
