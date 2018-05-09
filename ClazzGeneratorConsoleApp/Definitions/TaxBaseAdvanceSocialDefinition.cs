namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseAdvanceSocialDefinition : ArticleDefinition
	{
		public TaxBaseAdvanceSocialDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_ADVANCE_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
