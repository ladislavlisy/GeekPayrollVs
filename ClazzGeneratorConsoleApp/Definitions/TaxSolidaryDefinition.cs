namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxSolidaryDefinition : ArticleDefinition
	{
		public TaxSolidaryDefinition() : base(ArticleCode.ARTCODE_TAX_SOLIDARY)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
