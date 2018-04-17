namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdPartDefinition : ArticleDefinition
	{
		public TaxWithholdPartDefinition() : base(ArticleCode.TARGET_TAX_WITHHOLD_PART)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
