namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxIncomesGeneralDefinition : ArticleDefinition
	{
		public TaxIncomesGeneralDefinition() : base(ArticleCode.FACT_TAX_INCOMES_GENERAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
