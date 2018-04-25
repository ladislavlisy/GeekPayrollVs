namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class ContractAttendItemDefinition : ArticleDefinition
    {
        public ContractAttendItemDefinition() : base(ArticleRole.ARTICLE_CONTRACT_ATTEND_ITEM)
        {
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("DayFrom", FieldType.TDay),
                CreateParam("DayStop", FieldType.TDay),
                CreateParam("PieceInDayFrom", FieldType.WorkDayPieceType),
                CreateParam("PieceInDayBetw", FieldType.WorkDayPieceType),
                CreateParam("PieceInDayStop", FieldType.WorkDayPieceType),
                CreateParam("HoursInDayFrom", FieldType.TSheetSeconds),
                CreateParam("HoursInDayBetw", FieldType.TSheetSeconds),
                CreateParam("HoursInDayStop", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
