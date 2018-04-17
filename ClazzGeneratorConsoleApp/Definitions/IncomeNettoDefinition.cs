namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class IncomeNettoDefinition : ArticleDefinition
	{
		public IncomeNettoDefinition() : base(ArticleCode.TARGET_INCOME_NETTO)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
