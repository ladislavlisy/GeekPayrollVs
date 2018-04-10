namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsHealthFinalDefinition : ArticleDefinition
	{
		public InsHealthFinalDefinition() : base(ArticleCode.ARTCODE_INS_HEALTH_FINAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
