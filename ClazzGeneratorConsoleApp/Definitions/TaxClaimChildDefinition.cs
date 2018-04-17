namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxClaimChildDefinition : ArticleDefinition
	{
		public TaxClaimChildDefinition() : base(ArticleCode.TARGET_TAX_CLAIM_CHILD)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
