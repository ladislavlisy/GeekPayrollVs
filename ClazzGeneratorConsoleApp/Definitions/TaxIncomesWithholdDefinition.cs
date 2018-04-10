namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxIncomesWithholdDefinition : ArticleDefinition
	{
		public TaxIncomesWithholdDefinition() : base(ArticleCode.ARTCODE_TAX_INCOMES_WITHHOLD)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
