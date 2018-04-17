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
        internal static void GenerateMethodForArticles(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.MethodsGen");

            ClazzGeneratorMethods service = new ClazzGeneratorMethods();

            service.DoSourceExport(genSourceFolder);
        }
        internal static void GenerateSourceForArticles(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.TargetsGen");

            ClazzGeneratorTargets service = new ClazzGeneratorTargets();

            service.DoSourceExport(genSourceFolder);
        }
        internal static void GenerateSourceForValues(string configFolder)
        {
            string genSourceFolder = System.IO.Path.Combine(configFolder, "ElementsLib\\Elements.Config.SourcesGen");

            ClazzGeneratorValues service = new ClazzGeneratorValues();

            service.DoSourceExport(genSourceFolder);
        }
    }
}
