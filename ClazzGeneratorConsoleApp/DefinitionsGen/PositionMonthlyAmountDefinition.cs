using System;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using Defs;
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    public class PositionMonthlyAmountDefinition : ArticleDefinition
    {
        public PositionMonthlyAmountDefinition() : base(ArticleRole.ARTICLE_POSITION_MONTHLY_AMOUNT)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
