namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class UnknownDefinition : ArticleDefinition
	{
		public UnknownDefinition() : base(ArticleRole.ARTICLE_UNKNOWN)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
