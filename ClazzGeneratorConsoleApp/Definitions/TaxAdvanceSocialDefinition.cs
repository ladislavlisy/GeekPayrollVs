namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxAdvanceSocialDefinition : ArticleDefinition
	{
		public TaxAdvanceSocialDefinition() : base(ArticleRole.ARTICLE_TAX_ADVANCE_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
