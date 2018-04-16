namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class ContractTimesheetDefinition : ArticleDefinition
	{
		public ContractTimesheetDefinition() : base(ArticleCode.ARTCODE_CONTRACT_TIMESHEET)
		{
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
