namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxReliefChildDefinition : ArticleDefinition
	{
		public TaxReliefChildDefinition() : base(ArticleCode.ARTCODE_TAX_RELIEF_CHILD)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
