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
        internal static void ExportArticlesConfigForLoad(string filesFolder)
        {
            string genSourcePath = System.IO.Path.Combine(filesFolder, "GetArticleRoleData.cs");
            var codes = ArticleCodeConfigBuilder.GetConfigDataList();
            var roles = ArticleRoleConfigBuilder.GetConfigDataList();

            FileInfo genSourceFile = new FileInfo(genSourcePath);
            FileStream genSourceStream = genSourceFile.Create();

            using (StreamWriter genSourceWriter = new StreamWriter(genSourceStream, System.Text.Encoding.GetEncoding("windows-1250")))
            {
                foreach (var code in codes)
                {
                    //new ArticleCodeConfigData(9, 9, 1, "FACT_CONTRACT_ABSENCE", 7, 6)
                    genSourceWriter.WriteLine(string.Format("new ArticleCodeConfigData({0}, {1}, {2}, \"{3}\", {4}),", 
                        code.Code.ToString(), code.Role.ToString(), code.Type.ToString(), code.Name,
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
