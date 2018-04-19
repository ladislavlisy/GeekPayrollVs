namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class PositionScheduleDefinition : ArticleDefinition
	{
		public PositionScheduleDefinition() : base(ArticleRole.ARTICLE_POSITION_SCHEDULE)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("ShiftLiable", FieldType.TSeconds),
                CreateParam("ShiftActual", FieldType.TSeconds),
                CreateParam("ScheduleType", FieldType.WorkScheduleType));
            ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
