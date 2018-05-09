using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxWithholdBaseDefinition : ArticleDefinition
    {
        public TaxWithholdBaseDefinition() : base(ArticleRole.ARTICLE_TAX_WITHHOLD_BASE)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
