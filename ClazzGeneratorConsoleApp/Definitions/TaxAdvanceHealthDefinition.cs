namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceHealthDefinition : ArticleDefinition
	{
		public TaxAdvanceHealthDefinition() : base(ArticleCode.TARGET_TAX_ADVANCE_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
