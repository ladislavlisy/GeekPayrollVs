using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ClazzGeneratorConsoleApp.Definitions
{
    using System.Collections.Generic;

    public class ContractTimesheetDefinition : ArticleDefinition
    {
        public ContractTimesheetDefinition() : base(ArticleRole.ARTICLE_ARTICLE_CONTRACT_TIMESHEET)
        {
            ArticleSources = ArticleDefinition.CreateParams();
            ArticleResults = ArticleDefinition.CreateParams();
        }
    }
}
