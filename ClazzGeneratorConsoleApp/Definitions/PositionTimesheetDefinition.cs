namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class PositionTimesheetDefinition : ArticleDefinition
	{
		public PositionTimesheetDefinition() : base(ArticleCode.TARGET_POSITION_TIMESHEET)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursSchedule", FieldType.TSheetSeconds),
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
