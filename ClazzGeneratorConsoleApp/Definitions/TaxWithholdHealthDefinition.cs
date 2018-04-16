namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdHealthDefinition : ArticleDefinition
	{
		public TaxWithholdHealthDefinition() : base(ArticleCode.ARTCODE_TAX_WITHHOLD_HEALTH)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
