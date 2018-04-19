using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    public class ClazzGeneratorTargets
    {
        private const string NAME_SPACE_PREFIX = "ElementsLib.Elements.Config.Articles";
        public void DoSourceExport(string filesFolder)
        {
            ClazzArticlesBook articles = new ClazzArticlesBook();

            articles.InitBook();

            foreach (ArticleDefinition article in articles.Book)
            {
                DoOneClassFileExport(filesFolder, article);
            }

        }

        private void DoOneClassExport(StreamWriter writer, NamespaceTargetBlok parent, ArticleDefinition article)
        {
            string articleClassName = article.ClassName();

            ClassTargetBlok classBlok = new ClassTargetBlok(parent, article.Article, articleClassName);

            classBlok.StartBlok(writer);
            classBlok.BlokBody(writer);
            classBlok.CloseBlok(writer);
        }

        private void DoOneClassFileExport(string filesFolder, ArticleDefinition article)
        {
            string articleClassName = article.FullClassName();

            string genSourcePath = System.IO.Path.Combine(filesFolder, articleClassName + ".cs");

            FileInfo genSourceFile = new FileInfo(genSourcePath);
            FileStream genSourceStream = genSourceFile.Create();

            using (StreamWriter genSourceWriter = new StreamWriter(genSourceStream, System.Text.Encoding.GetEncoding("windows-1250")))
            {
                NamespaceTargetBlok namespeceBlok = new NamespaceTargetBlok(NAME_SPACE_PREFIX);

                namespeceBlok.StartBlok(genSourceWriter);

                DoOneClassExport(genSourceWriter, namespeceBlok, article);

                namespeceBlok.CloseBlok(genSourceWriter);

                genSourceWriter.Flush();
            }
        }
    }
}
