namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxDeclarationDefinition : ArticleDefinition
	{
		public TaxDeclarationDefinition() : base(ArticleRole.ARTICLE_TAX_DECLARATION)
		{
			ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("SummarizeType", FieldType.WorkTaxingTerms),
                CreateParam("DeclaracyType", FieldType.BYTE),
                CreateParam("ResidencyType", FieldType.BYTE));

            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("SummarizeType", FieldType.WorkTaxingTerms),
                CreateParam("DeclaracyType", FieldType.BYTE),
                CreateParam("ResidencyType", FieldType.BYTE));
		}
	}
}
