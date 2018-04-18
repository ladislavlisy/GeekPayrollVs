namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class ContractTimesheetDefinition : ArticleDefinition
	{
		public ContractTimesheetDefinition() : base(ArticleCode.FACT_CONTRACT_TIMESHEET)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
