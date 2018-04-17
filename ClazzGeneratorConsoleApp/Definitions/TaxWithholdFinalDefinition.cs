namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdFinalDefinition : ArticleDefinition
	{
		public TaxWithholdFinalDefinition() : base(ArticleCode.TARGET_TAX_WITHHOLD_FINAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
