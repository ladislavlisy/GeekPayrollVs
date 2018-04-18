namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxReliefChildDefinition : ArticleDefinition
	{
		public TaxReliefChildDefinition() : base(ArticleCode.FACT_TAX_RELIEF_CHILD)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
