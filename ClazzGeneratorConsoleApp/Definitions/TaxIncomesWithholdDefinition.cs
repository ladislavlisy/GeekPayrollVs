namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxIncomesWithholdDefinition : ArticleDefinition
	{
		public TaxIncomesWithholdDefinition() : base(ArticleCode.FACT_TAX_INCOMES_WITHHOLD)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
