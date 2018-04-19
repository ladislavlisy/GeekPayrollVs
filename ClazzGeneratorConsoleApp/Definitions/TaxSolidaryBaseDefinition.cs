namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class TaxSolidaryBaseDefinition : ArticleDefinition
	{
		public TaxSolidaryBaseDefinition() : base(ArticleRole.ARTICLE_TAX_SOLIDARY_BASE)
		{
			ArticleSources = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
