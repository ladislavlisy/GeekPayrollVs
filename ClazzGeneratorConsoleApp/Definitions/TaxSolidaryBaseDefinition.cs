namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxSolidaryBaseDefinition : ArticleDefinition
	{
		public TaxSolidaryBaseDefinition() : base(ArticleCode.FACT_TAX_SOLIDARY_BASE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
