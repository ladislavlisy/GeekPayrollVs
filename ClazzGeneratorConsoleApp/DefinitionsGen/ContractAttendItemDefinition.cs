using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class ContractAttendItemDefinition : ArticleDefinition
    {
        public ContractAttendItemDefinition() : base(ArticleRole.ARTICLE_CONTRACT_ATTEND_ITEM)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
