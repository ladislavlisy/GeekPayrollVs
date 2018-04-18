namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceDefinition : ArticleDefinition
	{
		public TaxAdvanceDefinition() : base(ArticleCode.FACT_TAX_ADVANCE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
