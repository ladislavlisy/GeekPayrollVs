namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class ContractTermDefinition : ArticleDefinition
	{
		public ContractTermDefinition() : base(ArticleRole.ARTICLE_CONTRACT_TERM)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("DateFrom", FieldType.DATE),
                CreateParam("DateStop", FieldType.DATE),
                CreateParam("ContractType", FieldType.WorkEmployTerms));
			ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("term_status", FieldType.BYTE));
		}
    }
}
