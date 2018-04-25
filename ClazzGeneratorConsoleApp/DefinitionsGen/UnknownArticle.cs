using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class UnknownDefinition : ArticleDefinition
    {
        public UnknownDefinition() : base(ArticleRole.ARTICLE_ARTICLE_UNKNOWN)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
