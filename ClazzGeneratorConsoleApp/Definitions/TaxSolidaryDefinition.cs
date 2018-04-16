namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxSolidaryDefinition : ArticleDefinition
	{
		public TaxSolidaryDefinition() : base(ArticleCode.ARTCODE_TAX_SOLIDARY)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
