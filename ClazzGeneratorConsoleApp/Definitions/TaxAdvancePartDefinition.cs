namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvancePartDefinition : ArticleDefinition
	{
		public TaxAdvancePartDefinition() : base(ArticleCode.FACT_TAX_ADVANCE_PART)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
