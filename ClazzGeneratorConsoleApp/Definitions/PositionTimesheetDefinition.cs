namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class PositionTimesheetDefinition : ArticleDefinition
	{
		public PositionTimesheetDefinition() : base(ArticleCode.ARTCODE_POSITION_TIMESHEET)
		{
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("HoursSchedule", FieldType.TSheetSeconds),
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
