namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseAdvanceSolidaryDefinition : ArticleDefinition
	{
		public TaxBaseAdvanceSolidaryDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_ADVANCE_SOLIDARY)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
