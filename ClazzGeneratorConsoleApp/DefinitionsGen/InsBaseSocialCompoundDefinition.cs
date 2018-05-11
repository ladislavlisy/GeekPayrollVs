using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class InsBaseSocialCompoundDefinition : ArticleDefinition
    {
        public InsBaseSocialCompoundDefinition() : base(ArticleRole.ARTICLE_INS_BASE_SOCIAL_COMPOUND)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
