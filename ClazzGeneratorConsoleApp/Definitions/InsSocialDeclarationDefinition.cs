namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsSocialDeclarationDefinition : ArticleDefinition
	{
		public InsSocialDeclarationDefinition() : base(ArticleCode.ARTCODE_INS_SOCIAL_DECLARATION)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}