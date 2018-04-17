namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdSocialDefinition : ArticleDefinition
	{
		public TaxWithholdSocialDefinition() : base(ArticleCode.TARGET_TAX_WITHHOLD_SOCIAL)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
