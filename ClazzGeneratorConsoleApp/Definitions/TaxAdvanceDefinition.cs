namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxAdvanceDefinition : ArticleDefinition
	{
		public TaxAdvanceDefinition() : base(ArticleCode.ARTCODE_TAX_ADVANCE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
