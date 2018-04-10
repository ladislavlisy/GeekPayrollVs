namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class PositionMonthlyAmountDefinition : ArticleDefinition
	{
		public PositionMonthlyAmountDefinition() : base(ArticleCode.ARTCODE_POSITION_MONTHLY_AMOUNT)
		{
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("total_amount", FieldType.DECIMAL),
                CreateRefer("shift_liable", FieldType.SHORT, ArticleCode.ARTCODE_POSITION_SCHEDULE),  // Pln� �vazek
                CreateRefer("shift_worked", FieldType.SHORT, ArticleCode.ARTCODE_POSITION_SCHEDULE),  // Skute�n� �vazek
                CreateRefer("hours_liable", FieldType.SHORT, ArticleCode.ARTCODE_POSITION_TIMESHEET), // Hodin skute�n�ho �vazku
                CreateRefer("hours_worked", FieldType.SHORT, ArticleCode.ARTCODE_POSITION_WORKING));  // Hodin odpracov�no
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
