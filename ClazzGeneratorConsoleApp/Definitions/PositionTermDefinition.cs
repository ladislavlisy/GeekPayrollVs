namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class PositionTermDefinition : ArticleDefinition
	{
		public PositionTermDefinition() : base(ArticleRole.ARTICLE_POSITION_TERM)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("DateFrom", FieldType.DATE),
                CreateParam("DateStop", FieldType.DATE),
                CreateParam("PositionType", FieldType.WorkPositionType));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
