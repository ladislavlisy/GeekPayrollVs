using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ElementsLib.Elements.Config.Source;
using ElementsLib.Elements.Config.Articles;
using ElementsLib.Legalist.Constants;
using ElementsLib.Module.Json;
using ElementsLib.Module.Interfaces.Elements;

namespace ExportJsonConsoleApp
{
    static class ProgramModule
    {
        public static void LoadSourceJson(string configFolder)
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
    }
}
