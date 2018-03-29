using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using SymbolCode = Module.Codes.ArticleCzCode;

    using Module.Interfaces;
    using Module.Codes;

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
            InternalCode = articleCode;
            InternalRole = articleRole;
            ResolvePath = resolvePath.ToList();
        }

        protected ConfigCode InternalCode { get; set; }
        protected ConfigRole InternalRole { get; set; }
        protected IList<ConfigCode> ResolvePath { get; set; }

        public ConfigCode Code()
        {
            return InternalCode;
        }
        public ConfigRole Role()
        {
            return InternalRole;
        }
        public ConfigCode[] Path()
        {
            return ResolvePath.ToArray();
        }

        public override string ToString()
        {
            SymbolCode symbol = ArticleCodeAdapter.CreateEnum(InternalCode);

            return symbol.GetSymbol();
        }
    }
}
