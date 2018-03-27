using ElementsLib;
using ElementsLib.ModuleConfig.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGeekConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFolder = ConfigFilesFolder();

            SaveConfigToJson(configFolder);
        }

        private static void SaveConfigToJson(string configFolder)
        {
            IList<ArticleConfigJson> configList = new List<ArticleConfigJson>()
            {
                new ArticleConfigJson() {
                    Code = "ARTCODE_UNKNOWN", Role = "ARTROLE_UNKNOWN", ResolvePath = new string[] { }
                },
                new ArticleConfigJson() {
                    Code = "ARTCODE_CONTRACT_TERM", Role = "ARTROLE_CONTRACT_TERM", ResolvePath = new string[] { }
                },
                new ArticleConfigJson() {
                    Code = "ARTCODE_POSITION_TERM", Role = "ARTROLE_POSITION_TERM", ResolvePath = new string[] { "ARTCODE_CONTRACT_TERM" }
                },
            };

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");
            ConfigJsonReader.SaveJsonData<ArticleConfigJson>(configFilePath, configList);
        }
        private static void loadConfigFromJson(string configFolder)
        {
            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");

            IList<ArticleConfigJson> configList = ConfigJsonReader.ReadJsonData<ArticleConfigJson>(configFilePath);
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
