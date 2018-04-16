namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class ContractWorkingDefinition : ArticleDefinition
    {
        public ContractWorkingDefinition() : base(ArticleCode.ARTCODE_CONTRACT_WORKING)
        {
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("HoursInPeriod", FieldType.TSheetSeconds));
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
