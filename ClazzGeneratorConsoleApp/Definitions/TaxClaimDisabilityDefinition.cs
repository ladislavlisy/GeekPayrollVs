namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxClaimDisabilityDefinition : ArticleDefinition
	{
		public TaxClaimDisabilityDefinition() : base(ArticleCode.ARTCODE_TAX_CLAIM_DISABILITY)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
