namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class ContractTermDefinition : ArticleDefinition
	{
		public ContractTermDefinition() : base(ArticleCode.ARTCODE_CONTRACT_TERM)
		{
            ArticleTargets = ArticleDefinition.CreateParams(
                CreateParam("DateFrom", FieldType.DATE),
                CreateParam("DateStop", FieldType.DATE),
                CreateParam("ContractType", FieldType.WorkEmployTerms));
			ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("term_status", FieldType.BYTE));
		}
    }
}
