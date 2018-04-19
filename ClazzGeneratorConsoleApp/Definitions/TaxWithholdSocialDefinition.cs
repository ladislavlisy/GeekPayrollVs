namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxWithholdSocialDefinition : ArticleDefinition
	{
		public TaxWithholdSocialDefinition() : base(ArticleRole.ARTICLE_TAX_WITHHOLD_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
