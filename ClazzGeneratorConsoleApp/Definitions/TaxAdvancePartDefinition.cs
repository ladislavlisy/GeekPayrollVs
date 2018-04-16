namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxAdvancePartDefinition : ArticleDefinition
	{
		public TaxAdvancePartDefinition() : base(ArticleCode.ARTCODE_TAX_ADVANCE_PART)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
