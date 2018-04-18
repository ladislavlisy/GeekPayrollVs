namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdHealthDefinition : ArticleDefinition
	{
		public TaxWithholdHealthDefinition() : base(ArticleCode.FACT_TAX_WITHHOLD_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
