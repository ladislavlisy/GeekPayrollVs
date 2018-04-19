namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class PositionTimesheetDefinition : ArticleDefinition
	{
		public PositionTimesheetDefinition() : base(ArticleRole.ARTICLE_POSITION_TIMESHEET)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursSchedule", FieldType.TSheetSeconds),
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
