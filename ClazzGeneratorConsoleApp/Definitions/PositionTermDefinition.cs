namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class PositionTermDefinition : ArticleDefinition
	{
		public PositionTermDefinition() : base(ArticleCode.FACT_POSITION_TERM)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("DateFrom", FieldType.DATE),
                CreateParam("DateStop", FieldType.DATE),
                CreateParam("PositionType", FieldType.WorkPositionType));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
