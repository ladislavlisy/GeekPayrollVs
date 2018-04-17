namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxClaimDisabilityDefinition : ArticleDefinition
	{
		public TaxClaimDisabilityDefinition() : base(ArticleCode.TARGET_TAX_CLAIM_DISABILITY)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
