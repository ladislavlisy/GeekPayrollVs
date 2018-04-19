namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsSocialDeclarationDefinition : ArticleDefinition
	{
		public InsSocialDeclarationDefinition() : base(ArticleRole.ARTICLE_INS_SOCIAL_DECLARATION)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
