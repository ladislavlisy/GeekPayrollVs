using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseSolidaryDefinition : ArticleDefinition
    {
        public TaxBaseSolidaryDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_SOLIDARY)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
