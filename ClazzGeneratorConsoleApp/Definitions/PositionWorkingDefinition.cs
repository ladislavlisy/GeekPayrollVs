namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class PositionWorkingDefinition : ArticleDefinition
    {
        public PositionWorkingDefinition() : base(ArticleCode.FACT_POSITION_WORKING)
        {
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
