namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsHealthBaseDefinition : ArticleDefinition
	{
		public InsHealthBaseDefinition() : base(ArticleCode.ARTCODE_INS_HEALTH_BASE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
