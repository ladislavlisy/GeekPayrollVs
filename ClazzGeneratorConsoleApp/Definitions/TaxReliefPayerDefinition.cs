namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxReliefPayerDefinition : ArticleDefinition
	{
		public TaxReliefPayerDefinition() : base(ArticleCode.ARTCODE_TAX_RELIEF_PAYER)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
