namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvanceHealthDefinition : ArticleDefinition
	{
		public TaxAdvanceHealthDefinition() : base(ArticleCode.ARTCODE_TAX_ADVANCE_HEALTH)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
