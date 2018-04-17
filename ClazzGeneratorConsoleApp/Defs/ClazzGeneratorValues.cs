using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    public class ClazzGeneratorValues
    {
        private const string NAME_SPACE_PREFIX = "ElementsLib.Elements.Config.Sources";
        public void DoSourceExport(string filesFolder)
        {
            ClazzArticlesBook articles = new ClazzArticlesBook();

            articles.InitBook();

            foreach (ArticleDefinition article in articles.Book)
            {
                DoOneClassFileExport(filesFolder, article);
            }
        }

        private void DoOneClassExport(StreamWriter writer, NamespaceArticleValuesBlok parent, ArticleDefinition article)
        {
            string articleClassName = article.ClassName();

            ClassArticleValuesBlok classBlok = new ClassArticleValuesBlok(parent, article.Article, article, articleClassName);

            classBlok.StartBlok(writer);
            classBlok.BlokBody(writer);
            classBlok.CloseBlok(writer);
        }

        private void DoOneClassFileExport(string filesFolder, ArticleDefinition article)
        {
            string articleClassName = article.ValsClassName();

            string genSourcePath = System.IO.Path.Combine(filesFolder, articleClassName + ".cs");

            FileInfo genSourceFile = new FileInfo(genSourcePath);
            FileStream genSourceStream = genSourceFile.Create();

            using (StreamWriter genSourceWriter = new StreamWriter(genSourceStream, System.Text.Encoding.GetEncoding("windows-1250")))
            {
                NamespaceArticleValuesBlok namespeceBlok = new NamespaceArticleValuesBlok(NAME_SPACE_PREFIX);

                namespeceBlok.StartBlok(genSourceWriter);

                DoOneClassExport(genSourceWriter, namespeceBlok, article);

                namespeceBlok.CloseBlok(genSourceWriter);

                genSourceWriter.Flush();
            }
        }
    }
}
