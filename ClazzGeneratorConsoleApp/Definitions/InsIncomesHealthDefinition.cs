namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsIncomesHealthDefinition : ArticleDefinition
	{
		public InsIncomesHealthDefinition() : base(ArticleCode.TARGET_INS_INCOMES_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
