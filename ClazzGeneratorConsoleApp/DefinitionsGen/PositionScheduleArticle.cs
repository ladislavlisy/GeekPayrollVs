using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class PositionScheduleDefinition : ArticleDefinition
    {
        public PositionScheduleDefinition() : base(ArticleRole.ARTICLE_ARTICLE_POSITION_SCHEDULE)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
