namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    public class TaxWithholdFinalDefinition : ArticleDefinition
	{
		public TaxWithholdFinalDefinition() : base(ArticleCode.ARTCODE_TAX_WITHHOLD_FINAL)
		{
			ArticleTargets = ArticleDefinition.CreateParams();
			ArticleResults = ArticleDefinition.CreateParams();
		}
	}
}
