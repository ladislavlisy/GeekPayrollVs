using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class PositionAbsenceDefinition : ArticleDefinition
    {
        public PositionAbsenceDefinition() : base(ArticleRole.ARTICLE_ARTICLE_POSITION_ABSENCE)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
