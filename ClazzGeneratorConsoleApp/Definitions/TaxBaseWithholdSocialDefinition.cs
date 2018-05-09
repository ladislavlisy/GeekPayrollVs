namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseWithholdSocialDefinition : ArticleDefinition
	{
		public TaxBaseWithholdSocialDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_WITHHOLD_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
