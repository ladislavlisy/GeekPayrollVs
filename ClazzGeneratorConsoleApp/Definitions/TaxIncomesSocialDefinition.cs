namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxIncomesSocialDefinition : ArticleDefinition
    {
        public TaxIncomesSocialDefinition() : base(ArticleRole.ARTICLE_TAX_INCOMES_SOCIAL)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("SummarizeType", FieldType.WorkTaxingTerms),
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("ResidencyType", FieldType.BYTE),
                CreateParam("IncomeGeneral", FieldType.TAmount),
                CreateParam("IncomeExclude", FieldType.TAmount),
                CreateParam("IncomeAgrTask", FieldType.TAmount),
                CreateParam("IncomePartner", FieldType.TAmount));
        }
    }
}
