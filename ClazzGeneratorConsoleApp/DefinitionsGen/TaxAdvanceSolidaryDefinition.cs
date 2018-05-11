using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxAdvanceSolidaryDefinition : ArticleDefinition
    {
        public TaxAdvanceSolidaryDefinition() : base(ArticleRole.ARTICLE_TAX_ADVANCE_SOLIDARY)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
