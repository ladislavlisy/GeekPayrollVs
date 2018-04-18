using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsLib.Module.Codes;

namespace ClazzGeneratorConsoleApp.Defs
{
    using ConfigRoleEnum = ArticleRoleCz;
    using ConfigRole = UInt16;

    using ElementsLib.Module.Common;
    public class ClazzGeneratorMethods
    {
        private const string ROLE_NAME_CLASS_POSTFIX = "Method";
        private const string ROLE_NAME_CLASS_PATTERN = "ARTICLE_(.*)";

        private const string ROLE_NAME_SPACE_PATTERN = "ElementsLib.Elements.Config.Methods";
        public void DoSourceExport(string filesFolder)
        {
            var articles = ArticleRoleAdapter.GetSelectedEnums();

            foreach (var article in articles)
            {
                DoOneClassFileExport(filesFolder, article);
            }
        }

        private void DoOneClassExport(StreamWriter writer, NamespaceMethodBlok parent, ConfigRoleEnum article)
        {
            string articleClassName = GeneralNamesFactory.ClassNameFor("", ROLE_NAME_CLASS_PATTERN, article.GetSymbol());

            ClassMethodBlok classBlok = new ClassMethodBlok(parent, article, articleClassName);

            classBlok.StartBlok(writer);
            classBlok.BlokBody(writer);
            classBlok.CloseBlok(writer);
        }

        private void DoOneClassFileExport(string filesFolder, ConfigRoleEnum article)
        {
            string articleClassName = GeneralNamesFactory.ClassNameFor(ROLE_NAME_CLASS_POSTFIX, ROLE_NAME_CLASS_PATTERN, article.GetSymbol()); 

            string genSourcePath = System.IO.Path.Combine(filesFolder, articleClassName + ".cs");

            FileInfo genSourceFile = new FileInfo(genSourcePath);
            FileStream genSourceStream = genSourceFile.Create();

            using (StreamWriter genSourceWriter = new StreamWriter(genSourceStream, System.Text.Encoding.GetEncoding("windows-1250")))
            {
                NamespaceMethodBlok namespeceBlok = new NamespaceMethodBlok(ROLE_NAME_SPACE_PATTERN);

                namespeceBlok.StartBlok(genSourceWriter);

                DoOneClassExport(genSourceWriter, namespeceBlok, article);

                namespeceBlok.CloseBlok(genSourceWriter);

                genSourceWriter.Flush();
            }
        }
    }
}
