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
                CreateParam("IncomeGeneral", FieldType.TAmountDec),
                CreateParam("IncomeExclude", FieldType.TAmountDec),
                CreateParam("IncomeTaskAgr", FieldType.TAmountDec),
                CreateParam("IncomePartner", FieldType.TAmountDec));
        }
    }
}
