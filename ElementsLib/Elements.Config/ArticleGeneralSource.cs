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

    public abstract class ArticleGeneralSource : IArticleSource, ICloneable
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

        public abstract void ImportSourceValues(ISourceValues values);

        public abstract IArticleSource CloneSourceAndSetValues(ISourceValues values);

        public virtual object Clone()
        {
            ArticleGeneralSource clone = (ArticleGeneralSource)this.MemberwiseClone();
            clone.InternalCode = this.InternalCode;

            return clone;
        }
        public override string ToString()
        {
            SymbolCode symbol = ArticleCodeAdapter.CreateEnum(InternalCode);

            return symbol.GetSymbol();
        }
    }
}
