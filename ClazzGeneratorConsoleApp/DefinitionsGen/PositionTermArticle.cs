using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class PositionTermDefinition : ArticleDefinition
    {
        public PositionTermDefinition() : base(ArticleRole.ARTICLE_ARTICLE_POSITION_TERM)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
