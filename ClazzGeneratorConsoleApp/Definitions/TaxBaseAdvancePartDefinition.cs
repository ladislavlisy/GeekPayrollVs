namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseAdvancePartDefinition : ArticleDefinition
	{
		public TaxBaseAdvancePartDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_ADVANCE_PART)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
