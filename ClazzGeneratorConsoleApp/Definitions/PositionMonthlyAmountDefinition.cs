namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class PositionMonthlyAmountDefinition : ArticleDefinition
	{
		public PositionMonthlyAmountDefinition() : base(ArticleCode.TARGET_POSITION_MONTHLY_AMOUNT)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("total_amount", FieldType.DECIMAL),
                CreateRefer("shift_liable", FieldType.SHORT, ArticleCode.TARGET_POSITION_SCHEDULE),  // Pln� �vazek
                CreateRefer("shift_worked", FieldType.SHORT, ArticleCode.TARGET_POSITION_SCHEDULE),  // Skute�n� �vazek
                CreateRefer("hours_liable", FieldType.SHORT, ArticleCode.TARGET_POSITION_TIMESHEET), // Hodin skute�n�ho �vazku
                CreateRefer("hours_worked", FieldType.SHORT, ArticleCode.TARGET_POSITION_WORKING));  // Hodin odpracov�no
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
