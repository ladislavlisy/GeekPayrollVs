namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    public class TaxWithholdSocialDefinition : ArticleDefinition
	{
		public TaxWithholdSocialDefinition() : base(ArticleCode.ARTCODE_TAX_WITHHOLD_SOCIAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
