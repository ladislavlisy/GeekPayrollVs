namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class IncomeGrossDefinition : ArticleDefinition
	{
		public IncomeGrossDefinition() : base(ArticleCode.ARTCODE_INCOME_GROSS)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
