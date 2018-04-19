namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxClaimStudyingDefinition : ArticleDefinition
	{
		public TaxClaimStudyingDefinition() : base(ArticleRole.ARTICLE_TAX_CLAIM_STUDYING)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
