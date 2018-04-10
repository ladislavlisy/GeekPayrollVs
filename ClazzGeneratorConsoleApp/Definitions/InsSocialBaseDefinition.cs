namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsSocialBaseDefinition : ArticleDefinition
	{
		public InsSocialBaseDefinition() : base(ArticleCode.ARTCODE_INS_SOCIAL_BASE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
