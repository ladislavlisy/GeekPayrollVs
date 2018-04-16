namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxClaimChildDefinition : ArticleDefinition
	{
		public TaxClaimChildDefinition() : base(ArticleCode.ARTCODE_TAX_CLAIM_CHILD)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
