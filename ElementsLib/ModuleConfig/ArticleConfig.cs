using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.ModuleConfig
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
        public ArticleConfig(ConfigCode articleCode, ConfigRole articleRole, params ConfigCode[] resolvePath)
        {
            ArticleCode = articleCode;
            ArticleRole = articleRole;
            ResolvePath = resolvePath.ToList();
        }

        protected ConfigCode ArticleCode { get; set; }
        protected ConfigRole ArticleRole { get; set; }
        protected IList<ConfigCode> ResolvePath { get; set; }

        public ConfigCode Code()
        {
            return ArticleCode;
        }
        public ConfigRole Role()
        {
            return ArticleRole;
        }
        public ConfigCode[] Path()
        {
            return ResolvePath.ToArray();
        }

        public override string ToString()
        {
            return ArticleCode.ToString();
        }
    }
}
