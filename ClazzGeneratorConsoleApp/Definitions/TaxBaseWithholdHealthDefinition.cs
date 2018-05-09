namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseWithholdHealthDefinition : ArticleDefinition
	{
		public TaxBaseWithholdHealthDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_WITHHOLD_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
