using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxAdvanceOrdinaryDefinition : ArticleDefinition
    {
        public TaxAdvanceOrdinaryDefinition() : base(ArticleRole.ARTICLE_TAX_ADVANCE_ORDINARY)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
