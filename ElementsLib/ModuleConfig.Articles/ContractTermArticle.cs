using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.ModuleConfig.Targets
{
    using TargetCode = ArticleCode;
    public class ContractTermArticle : GeneralArticleSource
    {
        public ContractTermArticle() : base(TargetCode.ARTICLE_CONTRACT_TERM)
        {

        }
    }
}
