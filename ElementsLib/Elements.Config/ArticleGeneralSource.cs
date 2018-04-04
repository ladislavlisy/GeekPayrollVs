using System;

namespace ElementsLib.Elements.Config
{
    using SourceCode = UInt16;
    using SymbolCode = Module.Codes.ArticleCzCode;

    using Module.Codes;
    using Module.Interfaces.Elements;

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

        public ISourceValues ExportSourceValues()
        {
            return null;
        }

        public void ImportSourceValues(ISourceValues values)
        {
        }

        public override string ToString()
        {
            SymbolCode symbol = ArticleCodeAdapter.CreateEnum(InternalCode);

            return symbol.GetSymbol();
        }
    }
}
