namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxWithholdFinalDefinition : ArticleDefinition
	{
		public TaxWithholdFinalDefinition() : base(ArticleRole.ARTICLE_TAX_WITHHOLD_FINAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
