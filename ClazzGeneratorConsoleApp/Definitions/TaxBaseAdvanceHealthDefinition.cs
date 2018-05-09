namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseAdvanceHealthDefinition : ArticleDefinition
	{
		public TaxBaseAdvanceHealthDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_ADVANCE_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
