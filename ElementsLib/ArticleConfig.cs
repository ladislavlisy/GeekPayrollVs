using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    using Interfaces;
    
    // ArticleConfig = 
    // ArticleCode, 
    // ConceptCode, 
    // ArticleVals, 
    // ResolveCodes, xx 
    // SummaryCodes, 
    // IncomesRules
    // Create ArticleSource

    public class ArticleConfig : IArticleConfig
    {
        public ArticleConfig(ConfigCode articleCode, ConfigRole articleRole, ConfigCode[] resolvePath)
        {
            Code = articleCode;
            Role = articleRole;
            ResolvePath = resolvePath.ToList();
        }

        public ConfigCode Code { get; protected set; }
        public ConfigRole Role { get; protected set; }
        public IList<ConfigCode> ResolvePath { get; protected set; }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
