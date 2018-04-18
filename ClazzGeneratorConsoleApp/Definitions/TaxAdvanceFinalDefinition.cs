namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceFinalDefinition : ArticleDefinition
	{
		public TaxAdvanceFinalDefinition() : base(ArticleCode.FACT_TAX_ADVANCE_FINAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
