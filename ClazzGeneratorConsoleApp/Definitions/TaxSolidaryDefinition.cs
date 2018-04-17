namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxSolidaryDefinition : ArticleDefinition
	{
		public TaxSolidaryDefinition() : base(ArticleCode.TARGET_TAX_SOLIDARY)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
