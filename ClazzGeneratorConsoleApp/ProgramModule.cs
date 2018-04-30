using ClazzGeneratorConsoleApp.Defs;
using ElementsLib.Module.Codes;
using ElementsLib.Service.Permadom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp
{
    public class ProgramModule
    {
        internal static void GenerateDefinitionForArticles(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ClazzGeneratorConsoleApp\\DefinitionsGen");

            ClazzGeneratorDefinitions service = new ClazzGeneratorDefinitions();

            service.DoSourceExport(genSourceFolder);
        }
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
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.ConceptsGen");

            ClazzGeneratorResults service = new ClazzGeneratorResults();

            service.DoSourceExport(genSourceFolder);
        }
    }
}
