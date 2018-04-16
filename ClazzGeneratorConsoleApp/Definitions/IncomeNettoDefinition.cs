namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class IncomeNettoDefinition : ArticleDefinition
	{
		public IncomeNettoDefinition() : base(ArticleCode.ARTCODE_INCOME_NETTO)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
