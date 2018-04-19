namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxWithholdHealthDefinition : ArticleDefinition
	{
		public TaxWithholdHealthDefinition() : base(ArticleRole.ARTICLE_TAX_WITHHOLD_HEALTH)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
