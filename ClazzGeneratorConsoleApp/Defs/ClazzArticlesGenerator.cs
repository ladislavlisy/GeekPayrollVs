using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    public class ClazzArticlesGenerator
    {
        private const string NAME_SPACE_PREFIX = "ElementsLib.Elements.Config.Articles";
        public void DoSourceExport(string filesFolder)
        {
            ClazzArticlesBook articles = new ClazzArticlesBook();

            articles.InitBook();

#if __ONE_FILE__ == true
            string genSourcePath = System.IO.Path.Combine(filesFolder, "ArticleElements.cs");

            FileInfo genSourceFile = new FileInfo(genSourcePath);
            FileStream genSourceStream = genSourceFile.Create();

            using (StreamWriter genSourceWriter = new StreamWriter(genSourceStream, System.Text.Encoding.GetEncoding("windows-1250")))
            {
                NamespaceBlok namespeceBlok = new NamespaceBlok("ArticleLib");

                namespeceBlok.StartBlok(genSourceWriter);

                foreach (ArticleDefinition article in articles.Book)
                {
                    DoInitClassExport(genSourceWriter, namespeceBlok, article);
                }

                namespeceBlok.CloseBlok(genSourceWriter);

                genSourceWriter.Flush();
            }
#endif
            foreach (ArticleDefinition article in articles.Book)
            {
                DoOneClassFileExport(filesFolder, article);
            }

        }

        private void DoInitClassExport(StreamWriter writer, NamespaceArticleSourceBlok parent, ArticleDefinition article)
        {
            string articleClassName = article.ClassName();

            DefinitionInstanceArticleBlok classBlok = new DefinitionInstanceArticleBlok(parent, article.Article, articleClassName);

            classBlok.BlokBody(writer);
        }

        private void DoOneClassExport(StreamWriter writer, NamespaceArticleSourceBlok parent, ArticleDefinition article)
        {
            string articleClassName = article.ClassName();

            ClassArticleSourceBlok classBlok = new ClassArticleSourceBlok(parent, article.Article, articleClassName);

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
                NamespaceArticleSourceBlok namespeceBlok = new NamespaceArticleSourceBlok(NAME_SPACE_PREFIX);

                namespeceBlok.StartBlok(genSourceWriter);

                DoOneClassExport(genSourceWriter, namespeceBlok, article);

                namespeceBlok.CloseBlok(genSourceWriter);

                genSourceWriter.Flush();
            }
        }
    }
}
