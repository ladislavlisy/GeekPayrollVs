namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsSocialFinalDefinition : ArticleDefinition
	{
		public InsSocialFinalDefinition() : base(ArticleCode.ARTCODE_INS_SOCIAL_FINAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
