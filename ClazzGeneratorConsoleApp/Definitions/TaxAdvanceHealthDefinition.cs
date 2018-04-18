namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceHealthDefinition : ArticleDefinition
	{
		public TaxAdvanceHealthDefinition() : base(ArticleCode.FACT_TAX_ADVANCE_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
