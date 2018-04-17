namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class PositionAbsenceDefinition : ArticleDefinition
	{
		public PositionAbsenceDefinition() : base(ArticleCode.TARGET_POSITION_ABSENCE)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
