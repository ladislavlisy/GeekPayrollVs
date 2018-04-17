namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class ContractAbsenceDefinition : ArticleDefinition
	{
		public ContractAbsenceDefinition() : base(ArticleCode.TARGET_CONTRACT_ABSENCE)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
