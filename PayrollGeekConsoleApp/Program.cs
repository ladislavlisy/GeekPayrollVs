using System;
using System.Collections.Generic;
using ElementsLib.Matrixus.Config;
using ElementsLib.Module.Json;
using ElementsLib.Elements.Config;
using System.Reflection;
using ElementsLib;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Elements.Config.Source;

namespace PayrollGeekConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFolder = ConfigFilesFolder();

            LoadSourceJson();
        }

        private static void LoadSourceJson()
        {
            ContractTermSource articleSource = new ContractTermSource();

            string json = "{ \"DateFrom\": \"1.1.2010\", \"DateStop\": \"\", \"ContractType\": \"WORKTERM_EMPLOYMENT_1\"  }";

            articleSource.DeserializeValues(json);
        }

        private static void LoadSourceModel()
        {
            ArticleSourceCollection service = new ArticleSourceCollection();

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            service.InitConfigModel(configAssembly, configFactory);

            return;
        }
        private static void LoadConfigModel()
        {
            ArticleConfigCollection service = new ArticleConfigCollection();

            ArticleConfigFactory factory = new ArticleConfigFactory();

            service.InitConfigModel(factory);
        }

        private static void SaveConfigToJson(string configFolder)
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
        private static void loadConfigFromJson(string configFolder)
        {
            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");

            IList<ArticleConfigNameJson> configList = ConfigJsonReader.ReadJsonData<ArticleConfigNameJson>(configFilePath);
        }

        private static string ConfigFilesFolder()
        {
            string[] args = Environment.GetCommandLineArgs();

            string appExecutableFileNm = args[0];

            return ParentAppFolder(3, System.IO.Path.GetDirectoryName(appExecutableFileNm));
        }
        private static string ParentAppFolder(int levelsUp, string startDir)
        {
            string finalDir = startDir;
            for (int l = 0; l < levelsUp; l++)
            {
                finalDir = System.IO.Path.GetDirectoryName(finalDir);
            }
            return finalDir;
        }
    }
}
