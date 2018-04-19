namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class ContractTimesheetDefinition : ArticleDefinition
	{
		public ContractTimesheetDefinition() : base(ArticleRole.ARTICLE_CONTRACT_TIMESHEET)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
