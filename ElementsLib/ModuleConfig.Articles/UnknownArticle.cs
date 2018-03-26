using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.ModuleConfig.Targets
{
    using TargetCode = ArticleCode;
    public class UnknownArticle : GeneralArticleSource
    {
        public UnknownArticle() : base(TargetCode.ARTICLE_UNKNOWN)
        {

        }
    }
}
