namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxIncomesAdvanceDefinition : ArticleDefinition
	{
		public TaxIncomesAdvanceDefinition() : base(ArticleCode.FACT_TAX_INCOMES_ADVANCE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
