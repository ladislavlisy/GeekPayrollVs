namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdPartDefinition : ArticleDefinition
	{
		public TaxWithholdPartDefinition() : base(ArticleCode.ARTCODE_TAX_WITHHOLD_PART)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
