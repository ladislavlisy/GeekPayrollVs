namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsDeclarationSocialDefinition : ArticleDefinition
	{
		public InsDeclarationSocialDefinition() : base(ArticleRole.ARTICLE_INS_DECLARATION_SOCIAL)
		{
            ArticleSources = ArticleDefinition.CreateParams(
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("SummarizeType", FieldType.WorkSocialTerms));
            ArticleResults = ArticleDefinition.CreateParams(
                CreateParam("StatementType", FieldType.BYTE),
                CreateParam("SummarizeType", FieldType.WorkSocialTerms));
		}
	}
}
