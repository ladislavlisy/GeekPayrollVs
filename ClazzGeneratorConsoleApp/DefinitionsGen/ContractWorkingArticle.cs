using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class ContractWorkingDefinition : ArticleDefinition
    {
        public ContractWorkingDefinition() : base(ArticleRole.ARTICLE_ARTICLE_CONTRACT_WORKING)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
