namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdBaseDefinition : ArticleDefinition
	{
		public TaxWithholdBaseDefinition() : base(ArticleCode.TARGET_TAX_WITHHOLD_BASE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
