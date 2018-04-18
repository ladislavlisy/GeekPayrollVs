namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxClaimPayerDefinition : ArticleDefinition
	{
		public TaxClaimPayerDefinition() : base(ArticleCode.FACT_TAX_CLAIM_PAYER)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
