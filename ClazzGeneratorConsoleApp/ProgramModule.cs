using ClazzGeneratorConsoleApp.Defs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp
{
    public class ProgramModule
    {
        internal static void GenerateSourceForArticles(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.ArticlesGen");

            ClazzArticlesGenerator service = new ClazzArticlesGenerator();

            service.DoSourceExport(genSourceFolder);
        }
        internal static void GenerateSourceForValues(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.SourceGen");

            ClazzSourcesGenerator service = new ClazzSourcesGenerator();

            service.DoSourceExport(genSourceFolder);
        }
    }
}
