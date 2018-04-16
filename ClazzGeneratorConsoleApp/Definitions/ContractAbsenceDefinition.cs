namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class ContractAbsenceDefinition : ArticleDefinition
	{
		public ContractAbsenceDefinition() : base(ArticleCode.ARTCODE_CONTRACT_ABSENCE)
		{
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
