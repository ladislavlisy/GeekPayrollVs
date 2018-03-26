using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib
{
    using TargetCode = ArticleCode;

    public class GeneralArticleSource : IArticleSource
    {
        public GeneralArticleSource(TargetCode article)
        {
            Code = article;
        }

        public TargetCode Code { get; protected set; }

        public override string ToString()
        {
            return Code.GetSymbol();
        }
    }
}
