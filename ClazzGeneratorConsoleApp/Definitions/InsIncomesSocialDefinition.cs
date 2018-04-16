namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class InsIncomesSocialDefinition : ArticleDefinition
	{
		public InsIncomesSocialDefinition() : base(ArticleCode.ARTCODE_INS_INCOMES_SOCIAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
