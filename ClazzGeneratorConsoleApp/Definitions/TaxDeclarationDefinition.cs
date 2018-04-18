namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxDeclarationDefinition : ArticleDefinition
	{
		public TaxDeclarationDefinition() : base(ArticleCode.FACT_TAX_DECLARATION)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
