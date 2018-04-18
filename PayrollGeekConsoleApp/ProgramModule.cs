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
    using ElementsLib.Calculus;
    using ElementsLib.Matrixus;
    using ElementsLib.Legalist;
    using ElementsLib.Permadom;


    static class ProgramModule
    {
        public static void CreatePayrollData(string configFolder)
        {
            var memoryService = new SimplePermadomService();

            var matrixService = new SimpleMatrixusService();

            matrixService.InitializeService();

            var legalsService = new SimpleLegalistService();

            legalsService.InitializeService();

            var streamService = new SimpleElementsService(matrixService.Profile());

            streamService.InitializeService();

            var calculService = new SimpleCalculusService(matrixService.Profile());

            calculService.InitializeService();

            Period evalPeriod = new Period(2018, 1);

            IPeriodProfile evalProfile = legalsService.GetPeriodProfile(evalPeriod);

            calculService.EvaluateStore(streamService.SourceStream(), evalPeriod, evalProfile);

            List<SourcePair> evaluationPath = calculService.GetEvaluationPath();

            List<ResultPair> evaluationCase = calculService.GetEvaluationCase();

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_PAYROLL.TXT");

            try
            {
                StreamWriter writerFile = new StreamWriter(configFilePath, false, Encoding.GetEncoding("windows-1250"));

                evaluationPath.ForEach((c) => writerFile.WriteLine(c.Description()));

                evaluationCase.ForEach((c) => writerFile.WriteLine(c.Description()));

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
