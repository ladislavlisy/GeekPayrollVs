namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsSocialDeclarationDefinition : ArticleDefinition
	{
		public InsSocialDeclarationDefinition() : base(ArticleCode.FACT_INS_SOCIAL_DECLARATION)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
