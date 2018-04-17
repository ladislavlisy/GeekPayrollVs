namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsHealthDeclarationDefinition : ArticleDefinition
	{
		public InsHealthDeclarationDefinition() : base(ArticleCode.TARGET_INS_HEALTH_DECLARATION)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
