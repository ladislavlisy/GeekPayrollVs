namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsSocialBaseDefinition : ArticleDefinition
	{
		public InsSocialBaseDefinition() : base(ArticleCode.ARTCODE_INS_SOCIAL_BASE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
