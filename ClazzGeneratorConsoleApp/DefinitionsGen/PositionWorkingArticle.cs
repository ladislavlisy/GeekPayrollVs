using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class PositionWorkingDefinition : ArticleDefinition
    {
        public PositionWorkingDefinition() : base(ArticleRole.ARTICLE_ARTICLE_POSITION_WORKING)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
