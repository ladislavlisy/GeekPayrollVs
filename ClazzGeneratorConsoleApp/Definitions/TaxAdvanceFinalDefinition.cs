namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxAdvanceFinalDefinition : ArticleDefinition
	{
		public TaxAdvanceFinalDefinition() : base(ArticleCode.ARTCODE_TAX_ADVANCE_FINAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
