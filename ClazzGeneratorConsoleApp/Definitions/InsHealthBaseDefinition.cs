namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsHealthBaseDefinition : ArticleDefinition
	{
		public InsHealthBaseDefinition() : base(ArticleCode.TARGET_INS_HEALTH_BASE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
