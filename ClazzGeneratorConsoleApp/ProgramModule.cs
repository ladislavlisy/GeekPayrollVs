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

            ClazzGeneratorTargets service = new ClazzGeneratorTargets();

            service.DoSourceExport(genSourceFolder);
        }
        internal static void GenerateSourceForSources(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.SourcesGen");

            ClazzGeneratorValues service = new ClazzGeneratorValues();

            service.DoSourceExport(genSourceFolder);
        }
        internal static void GenerateSourceForResults(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.ResultsGen");

            ClazzGeneratorResults service = new ClazzGeneratorResults();

            service.DoSourceExport(genSourceFolder);
        }
    }
}
