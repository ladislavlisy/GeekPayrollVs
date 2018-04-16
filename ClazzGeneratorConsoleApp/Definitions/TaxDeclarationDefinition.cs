namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxDeclarationDefinition : ArticleDefinition
	{
		public TaxDeclarationDefinition() : base(ArticleCode.ARTCODE_TAX_DECLARATION)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
