using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class PositionTimesheetDefinition : ArticleDefinition
    {
        public PositionTimesheetDefinition() : base(ArticleRole.ARTICLE_ARTICLE_POSITION_TIMESHEET)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
