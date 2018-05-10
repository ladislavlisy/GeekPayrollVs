namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxIncomesHealthDefinition : ArticleDefinition
    {
        public TaxIncomesHealthDefinition() : base(ArticleRole.ARTICLE_TAX_INCOMES_HEALTH)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("SummarizeType", FieldType.WorkTaxingTerms),
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("ResidencyType", FieldType.BYTE),
                CreateParam("IncomeGeneral", FieldType.TAmountDec),
                CreateParam("IncomeExclude", FieldType.TAmountDec),
                CreateParam("IncomeAgrTask", FieldType.TAmountDec),
                CreateParam("IncomePartner", FieldType.TAmountDec));
        }
    }
}
