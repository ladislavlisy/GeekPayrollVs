namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxClaimStudyingDefinition : ArticleDefinition
	{
		public TaxClaimStudyingDefinition() : base(ArticleCode.ARTCODE_TAX_CLAIM_STUDYING)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
