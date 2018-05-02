namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsIncomesSocialDefinition : ArticleDefinition
	{
		public InsIncomesSocialDefinition() : base(ArticleRole.ARTICLE_INS_INCOMES_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("SummarizeType", FieldType.WorkSocialTerms),
                CreateParam("IncomeExclude", FieldType.TAmount),
                CreateParam("IncomeRelated", FieldType.TAmount));
        }
    }
}
