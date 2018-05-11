namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseAdvancePartialDefinition : ArticleDefinition
	{
		public TaxBaseAdvancePartialDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_ADVANCE_PARTIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
