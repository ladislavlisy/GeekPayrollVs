namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxClaimDisabilityDefinition : ArticleDefinition
	{
		public TaxClaimDisabilityDefinition() : base(ArticleRole.ARTICLE_TAX_CLAIM_DISABILITY)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
