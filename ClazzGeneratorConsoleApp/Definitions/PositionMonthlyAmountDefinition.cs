namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class PositionMonthlyAmountDefinition : ArticleDefinition
	{
		public PositionMonthlyAmountDefinition() : base(ArticleRole.ARTICLE_POSITION_MONTHLY_AMOUNT)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("total_amount", FieldType.DECIMAL),
                CreateRefer("shift_liable", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_SCHEDULE),  // Plný Úvazek
                CreateRefer("shift_worked", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_SCHEDULE),  // Skuteèný úvazek
                CreateRefer("hours_liable", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_TIMESHEET), // Hodin skuteèného úvazku
                CreateRefer("hours_worked", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_WORKING));  // Hodin odpracováno
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
