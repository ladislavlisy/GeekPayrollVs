namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsHealthFinalDefinition : ArticleDefinition
	{
		public InsHealthFinalDefinition() : base(ArticleCode.FACT_INS_HEALTH_FINAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
