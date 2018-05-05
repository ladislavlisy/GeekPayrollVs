namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxIncomesGeneralDefinition : ArticleDefinition
	{
		public TaxIncomesGeneralDefinition() : base(ArticleRole.ARTICLE_TAX_INCOMES_GENERAL)
		{
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("SummarizeType", FieldType.WorkTaxingTerms),
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("ResidencyType", FieldType.BYTE),
                CreateParam("IncomeGeneral", FieldType.TAmount),
                CreateParam("IncomeAgrTask", FieldType.TAmount),
                CreateParam("IncomePartner", FieldType.TAmount),
                CreateParam("IncomeExclude", FieldType.TAmount));
        }
    }
}
