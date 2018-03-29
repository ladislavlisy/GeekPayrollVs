using System;

namespace ElementsLib.Elements.Config
{
    using SourceCode = UInt16;
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

    public class ArticleGeneralSource : IArticleSource
    {
        public ArticleGeneralSource(SourceCode code)
        {
            InternalCode = code;
        }

        protected SourceCode InternalCode { get; set; }

        public SourceCode Code()
        {
            return InternalCode;
        }

        public override string ToString()
        {
            SymbolCode symbol = ArticleCodeAdapter.CreateEnum(InternalCode);

            return symbol.GetSymbol();
        }
    }
}
