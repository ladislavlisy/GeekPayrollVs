namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsIncomesSocialDefinition : ArticleDefinition
	{
		public InsIncomesSocialDefinition() : base(ArticleCode.FACT_INS_INCOMES_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
