using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsDeclarationHealthDefinition : ArticleDefinition
    {
        public InsDeclarationHealthDefinition() : base(ArticleRole.ARTICLE_INS_DECLARATION_HEALTH)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
