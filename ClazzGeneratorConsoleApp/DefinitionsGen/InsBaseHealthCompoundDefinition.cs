using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsBaseHealthCompoundDefinition : ArticleDefinition
    {
        public InsBaseHealthCompoundDefinition() : base(ArticleRole.ARTICLE_INS_BASE_HEALTH_COMPOUND)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
