namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxBonusChildDefinition : ArticleDefinition
	{
		public TaxBonusChildDefinition() : base(ArticleCode.ARTCODE_TAX_BONUS_CHILD)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
