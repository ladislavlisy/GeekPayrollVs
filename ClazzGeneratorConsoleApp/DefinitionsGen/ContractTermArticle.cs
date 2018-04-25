using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class ContractTermDefinition : ArticleDefinition
    {
        public ContractTermDefinition() : base(ArticleRole.ARTICLE_ARTICLE_CONTRACT_TERM)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
