using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class ContractAbsenceDefinition : ArticleDefinition
    {
        public ContractAbsenceDefinition() : base(ArticleRole.ARTICLE_ARTICLE_CONTRACT_ABSENCE)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
