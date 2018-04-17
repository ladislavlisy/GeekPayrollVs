namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceSocialDefinition : ArticleDefinition
	{
		public TaxAdvanceSocialDefinition() : base(ArticleCode.TARGET_TAX_ADVANCE_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
