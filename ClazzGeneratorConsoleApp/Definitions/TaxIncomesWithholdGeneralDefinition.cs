namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxIncomesWithholdGeneralDefinition : ArticleDefinition
	{
		public TaxIncomesWithholdGeneralDefinition() : base(ArticleRole.ARTICLE_TAX_INCOMES_WITHHOLD_GENERAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("IncomeTaxable", FieldType.TAmount)
            );
		}
	}
}
