namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsHealthDeclarationDefinition : ArticleDefinition
	{
		public InsHealthDeclarationDefinition() : base(ArticleCode.ARTCODE_INS_HEALTH_DECLARATION)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
