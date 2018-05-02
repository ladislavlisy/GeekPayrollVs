using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsHealthDeclarationDefinition : ArticleDefinition
    {
        public InsHealthDeclarationDefinition() : base(ArticleRole.ARTICLE_INS_HEALTH_DECLARATION)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
