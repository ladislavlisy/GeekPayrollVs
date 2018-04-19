namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxAdvanceHealthDefinition : ArticleDefinition
	{
		public TaxAdvanceHealthDefinition() : base(ArticleRole.ARTICLE_TAX_ADVANCE_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
