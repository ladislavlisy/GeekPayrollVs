using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsBaseHealthEmployerDefinition : ArticleDefinition
    {
        public InsBaseHealthEmployerDefinition() : base(ArticleRole.ARTICLE_INS_BASE_HEALTH_EMPLOYER)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
