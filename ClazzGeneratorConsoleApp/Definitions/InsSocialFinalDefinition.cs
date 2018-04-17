namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsSocialFinalDefinition : ArticleDefinition
	{
		public InsSocialFinalDefinition() : base(ArticleCode.TARGET_INS_SOCIAL_FINAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
