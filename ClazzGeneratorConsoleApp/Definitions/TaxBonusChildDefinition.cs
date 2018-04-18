namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxBonusChildDefinition : ArticleDefinition
	{
		public TaxBonusChildDefinition() : base(ArticleCode.FACT_TAX_BONUS_CHILD)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
