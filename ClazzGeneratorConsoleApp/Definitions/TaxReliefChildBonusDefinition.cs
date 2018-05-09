namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxReliefChildBonusDefinition : ArticleDefinition
	{
		public TaxReliefChildBonusDefinition() : base(ArticleRole.ARTICLE_TAX_RELIEF_CHILD_BONUS)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
