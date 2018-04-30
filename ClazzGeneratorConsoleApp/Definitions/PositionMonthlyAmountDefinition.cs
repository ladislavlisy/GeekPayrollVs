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
                CreateParam("MonthlyAmount", FieldType.TAmount),
                CreateRefer("ShiftLiable", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_SCHEDULE),  // Plný Úvazek
                CreateRefer("ShiftWorked", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_SCHEDULE),  // Skuteèný úvazek
                CreateRefer("HoursLiable", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_TIMESHEET), // Hodin skuteèného úvazku
                CreateRefer("HoursWorked", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_WORKING));  // Hodin odpracováno
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("Payment", FieldType.TAmount));
		}
	}
}
