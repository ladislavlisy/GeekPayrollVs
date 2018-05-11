namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsBaseHealthEmployeeDefinition : ArticleDefinition
    {
        public InsBaseHealthEmployeeDefinition() : base(ArticleRole.ARTICLE_INS_BASE_HEALTH_EMPLOYEE)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
