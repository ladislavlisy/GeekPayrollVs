namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxAdvanceBaseDefinition : ArticleDefinition
	{
		public TaxAdvanceBaseDefinition() : base(ArticleCode.ARTCODE_TAX_ADVANCE_BASE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
