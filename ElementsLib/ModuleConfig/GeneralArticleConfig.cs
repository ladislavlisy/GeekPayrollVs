using ElementsLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.ModuleConfig
{
    using TargetCode = ArticleCode;
    using TargetRole = ConceptCode;

    // ArticleConfig = 
    // ArticleCode, 
    // ConceptCode, 
    // ArticleVals, 
    // ResolveCodes, xx 
    // SummaryCodes, 
    // IncomesRules
    // Create ArticleSource

    public class GeneralArticleConfig : IArticleConfig
    {
        public GeneralArticleConfig(TargetCode article)
        {
            Code = article;
        }

        public TargetCode Code { get; protected set; }
        public TargetRole Role { get; protected set; }
        public TargetCode[] ResolvePath { get; protected set; }

        public override string ToString()
        {
            return Code.GetSymbol();
        }
    }
}
