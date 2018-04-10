namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxClaimPayerDefinition : ArticleDefinition
	{
		public TaxClaimPayerDefinition() : base(ArticleCode.ARTCODE_TAX_CLAIM_PAYER)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
