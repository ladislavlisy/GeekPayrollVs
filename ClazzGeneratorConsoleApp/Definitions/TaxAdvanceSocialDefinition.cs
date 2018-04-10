namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxAdvanceSocialDefinition : ArticleDefinition
	{
		public TaxAdvanceSocialDefinition() : base(ArticleCode.ARTCODE_TAX_ADVANCE_SOCIAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
