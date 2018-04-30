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
                CreateRefer("ShiftLiable", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_SCHEDULE),  // Pln� �vazek
                CreateRefer("ShiftWorked", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_SCHEDULE),  // Skute�n� �vazek
                CreateRefer("HoursLiable", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_TIMESHEET), // Hodin skute�n�ho �vazku
                CreateRefer("HoursWorked", FieldType.SHORT, ArticleRole.ARTICLE_POSITION_WORKING));  // Hodin odpracov�no
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("Payment", FieldType.TAmount));
		}
	}
}
