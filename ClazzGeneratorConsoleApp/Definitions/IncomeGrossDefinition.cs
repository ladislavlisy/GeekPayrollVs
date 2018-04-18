namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class IncomeGrossDefinition : ArticleDefinition
	{
		public IncomeGrossDefinition() : base(ArticleCode.FACT_INCOME_GROSS)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
