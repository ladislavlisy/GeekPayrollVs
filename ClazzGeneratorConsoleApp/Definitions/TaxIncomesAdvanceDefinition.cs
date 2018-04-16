namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxIncomesAdvanceDefinition : ArticleDefinition
	{
		public TaxIncomesAdvanceDefinition() : base(ArticleCode.ARTCODE_TAX_INCOMES_ADVANCE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
