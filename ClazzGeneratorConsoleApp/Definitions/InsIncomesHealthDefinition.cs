namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class InsIncomesHealthDefinition : ArticleDefinition
	{
		public InsIncomesHealthDefinition() : base(ArticleCode.ARTCODE_INS_INCOMES_HEALTH)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
