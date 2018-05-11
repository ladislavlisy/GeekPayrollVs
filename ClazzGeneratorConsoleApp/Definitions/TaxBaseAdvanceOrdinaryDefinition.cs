namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseAdvanceOrdinaryDefinition : ArticleDefinition
    {
        public TaxBaseAdvanceOrdinaryDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_ADVANCE_ORDINARY)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
