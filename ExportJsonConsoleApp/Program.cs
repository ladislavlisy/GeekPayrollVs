using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsLib.Elements.Config.Source;
using ElementsLib.Legalist.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ElementsLib.Module.Json;
using System.IO;
using ElementsLib.Elements.Config.Articles;
using ElementsLib.Module.Interfaces.Elements;

namespace ExportJsonConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFolder = ConfigFilesFolder();

            LoadSourceJson(configFolder);
        }

        private static void LoadSourceJson(string configFolder)
        {
            DateTime? TestDateFrom = new DateTime(2010, 1, 1);
            DateTime? TestDateStop = null;

            var contractSource = new ContractTermArticle(
                new ContractTermSource(TestDateFrom, TestDateStop, WorkEmployTerms.WORKTERM_EMPLOYMENT_1));

            var positionSource = new PositionTermArticle(
                new PositionTermSource(TestDateFrom, TestDateStop, WorkPositionType.POSITION_EXCLUSIVE));

            var ImportArticleCollection = new IArticleSource[]
            {
                contractSource,
                positionSource,
            };

            //var articleSourceConverter = new ArticleJsonConverter<IArticleSource>();
            var contractSourceConverter = new ArticleJsonConverter<ContractTermArticle>();
            var positionSourceConverter = new ArticleJsonConverter<PositionTermArticle>();

            string configContent = JsonConvert.SerializeObject(ImportArticleCollection, Formatting.Indented,
                contractSourceConverter, positionSourceConverter);

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_SOURCE.JSON");

            try
            {
                StreamWriter writerFile = new StreamWriter(configFilePath, false, Encoding.GetEncoding("windows-1250"));

                writerFile.Write(configContent);

                writerFile.Flush();

                writerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
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
