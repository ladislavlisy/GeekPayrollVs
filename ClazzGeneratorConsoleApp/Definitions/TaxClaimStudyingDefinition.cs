namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxClaimStudyingDefinition : ArticleDefinition
	{
		public TaxClaimStudyingDefinition() : base(ArticleCode.FACT_TAX_CLAIM_STUDYING)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
