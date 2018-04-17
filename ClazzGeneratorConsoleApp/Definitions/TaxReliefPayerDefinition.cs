namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxReliefPayerDefinition : ArticleDefinition
	{
		public TaxReliefPayerDefinition() : base(ArticleCode.TARGET_TAX_RELIEF_PAYER)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
