namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceBaseDefinition : ArticleDefinition
	{
		public TaxAdvanceBaseDefinition() : base(ArticleCode.FACT_TAX_ADVANCE_BASE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
