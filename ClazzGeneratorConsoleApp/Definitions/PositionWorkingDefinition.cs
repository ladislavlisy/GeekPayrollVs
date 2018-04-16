namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class PositionWorkingDefinition : ArticleDefinition
    {
        public PositionWorkingDefinition() : base(ArticleCode.ARTCODE_POSITION_WORKING)
        {
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
