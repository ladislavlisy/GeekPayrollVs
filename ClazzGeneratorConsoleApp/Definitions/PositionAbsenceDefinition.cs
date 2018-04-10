namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class PositionAbsenceDefinition : ArticleDefinition
	{
		public PositionAbsenceDefinition() : base(ArticleCode.ARTCODE_POSITION_ABSENCE)
		{
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
