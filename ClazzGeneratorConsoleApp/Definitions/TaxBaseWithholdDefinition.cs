namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxBaseWithholdDefinition : ArticleDefinition
	{
		public TaxBaseWithholdDefinition() : base(ArticleRole.ARTICLE_TAX_BASE_WITHHOLD)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("TaxableBasis", FieldType.TAmountDec)
            );

        }
    }
}
