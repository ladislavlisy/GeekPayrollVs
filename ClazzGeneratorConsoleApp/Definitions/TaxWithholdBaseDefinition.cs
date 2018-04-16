namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdBaseDefinition : ArticleDefinition
	{
		public TaxWithholdBaseDefinition() : base(ArticleCode.ARTCODE_TAX_WITHHOLD_BASE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
