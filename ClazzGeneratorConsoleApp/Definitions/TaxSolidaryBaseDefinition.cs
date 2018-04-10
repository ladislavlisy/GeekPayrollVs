namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxSolidaryBaseDefinition : ArticleDefinition
	{
		public TaxSolidaryBaseDefinition() : base(ArticleCode.ARTCODE_TAX_SOLIDARY_BASE)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
