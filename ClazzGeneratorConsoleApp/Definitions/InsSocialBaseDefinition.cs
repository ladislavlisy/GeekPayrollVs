namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsSocialBaseDefinition : ArticleDefinition
	{
		public InsSocialBaseDefinition() : base(ArticleCode.TARGET_INS_SOCIAL_BASE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
