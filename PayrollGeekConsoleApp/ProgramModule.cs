using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

using ElementsLib.Elements.Config.Articles;
using ElementsLib.Elements;
using ElementsLib.Module.Json;

namespace PayrollGeekConsoleApp
{
    using SourcePair = KeyValuePair<ElementsLib.Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<ElementsLib.Module.Interfaces.Elements.IArticleSource, string>>;
    using ResultPair = KeyValuePair<ElementsLib.Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<ElementsLib.Module.Interfaces.Elements.IArticleResult, string>>;

    using ElementsLib.Module.Libs;
    using ElementsLib.Module.Items;
    using ElementsLib.Module.Interfaces.Legalist;
    using ElementsLib.Matrixus;
    using ElementsLib.Legalist;
    using ElementsLib.Service.Permadom;
    using ElementsLib.Service.Matrixus;
    using ElementsLib.Service.Legalist;
    using ElementsLib.Service.Calculus;
    using ElementsLib.Module.Interfaces.Elements;
    using System.Linq;
    using ElementsLib.Module.Codes;

    static class ProgramModule
    {
        public static void CreatePayrollData(string configFolder)
        {
            var memoryService = new SimplePermadomService();

            var matrixService = new SimpleMatrixusService();

            matrixService.InitializeService(memoryService);

            var legalsService = new SimpleLegalistService();

            legalsService.InitializeService();

            IArticleSourceStore sourceStore = new ArticleSourceStore(matrixService.Profile());

            var sourceData = memoryService.GetArticleSourceData();

            sourceStore.LoadSourceData(sourceData);

            var calculService = new SimpleCalculusService(matrixService.Profile());

            calculService.InitializeService();

            Period evalPeriod = new Period(2018, 1);

            IPeriodProfile evalProfile = legalsService.GetPeriodProfile(evalPeriod);

            calculService.EvaluateStore(sourceStore, evalPeriod, evalProfile);

            List<SourcePair> evaluationPath = calculService.GetEvaluationPath();

            List<ResultPair> evaluationCase = calculService.GetEvaluationCase();

            string articlesFilePath = System.IO.Path.Combine(configFolder, "PROCESS_ARTICLES.TXT");

            try
            {
                StreamWriter writerFile = new StreamWriter(articlesFilePath, false, Encoding.GetEncoding("windows-1250"));

                evaluationPath.ForEach((c) => writerFile.WriteLine(c.Description()));

                writerFile.Flush();

                writerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            string payrollFilePath = System.IO.Path.Combine(configFolder, "PROCESS_EVALUATE.TXT");

            try
            {
                StreamWriter writerFile = new StreamWriter(payrollFilePath, false, Encoding.GetEncoding("windows-1250"));

                //evaluationCase.ForEach((c) => writerFile.WriteLine(c.Description()));
                evaluationCase.ForEach((c) => writerFile.WriteLine(c.ToResultExport()));

                writerFile.Flush();

                writerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }
        public static void ExportArticlesConfigForLoad(string filesFolder)
        {
            string genSourcePath = System.IO.Path.Combine(filesFolder, "ARTICLE_CONFIG_DATA.TXT");
            var codes = ArticleCodeConfigBuilder.GetConfigDataList();
            var roles = ArticleRoleConfigBuilder.GetConfigDataList();

            FileInfo genSourceFile = new FileInfo(genSourcePath);
            FileStream genSourceStream = genSourceFile.Create();

            using (StreamWriter genSourceWriter = new StreamWriter(genSourceStream, System.Text.Encoding.GetEncoding("windows-1250")))
            {
                foreach (var code in codes)
                {
                    string GangSymbol = code.Gang.ToEnum<ArticleGang>().GetSymbol();
                    string TypeSymbol = code.Type.ToEnum<ArticleType>().GetSymbol();
                    string BindSymbol = code.Bind.ToEnum<ArticleBind>().GetSymbol();

                    //new ArticleCodeConfigData(9, 9, 1, "FACT_CONTRACT_ABSENCE", 7, 6)
                    genSourceWriter.WriteLine(string.Format("new ArticleCodeConfigData({0}, {1}, {2}, {3}, {4}, TAXING_NOTHING, HEALTH_NOTHING, SOCIAL_NOTHING, \"{5}\", {6}),",
                        code.Code.ToString(), code.Role.ToString(), GangSymbol, TypeSymbol, BindSymbol, code.Name,
                        string.Join(", ", code.Path.Select((p) => (p.ToString())))));
                }

                genSourceWriter.WriteLine();

                foreach (var role in roles)
                {
                    //new ArticleRoleConfigData(0, "ARTICLE_UNKNOWN")
                    genSourceWriter.WriteLine(string.Format("new ArticleRoleConfigData({0}, \"{1}\"),",
                        role.Role.ToString(), role.Name));
                }
                genSourceWriter.Flush();
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
            //ArticleStubCollection service = new ArticleStubCollection();

            //Assembly configAssembly = typeof(ElementsService).Assembly;

            //IArticleSourceFactory configFactory = new ArticleSourceFactory();

            //service.InitConfigModel(configAssembly, configFactory);

            return;
        }
        public static void SaveConfigToJson(string configFolder)
        {
            IList<ArticleConfigNameJson> configList = new List<ArticleConfigNameJson>()
            {
                new ArticleConfigNameJson() {
                    Code = "FACT_UNKNOWN", Role = "ARTICLE_UNKNOWN", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "FACT_CONTRACT_TERM", Role = "ARTICLE_CONTRACT_TERM", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "FACT_POSITION_TERM", Role = "ARTICLE_POSITION_TERM", ResolvePath = new string[] { "FACT_CONTRACT_TERM" }
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
