namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxAdvanceFinalDefinition : ArticleDefinition
	{
		public TaxAdvanceFinalDefinition() : base(ArticleRole.ARTICLE_TAX_ADVANCE_FINAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
