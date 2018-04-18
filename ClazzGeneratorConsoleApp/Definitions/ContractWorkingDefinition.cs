namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class ContractWorkingDefinition : ArticleDefinition
    {
        public ContractWorkingDefinition() : base(ArticleCode.FACT_CONTRACT_WORKING)
        {
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
