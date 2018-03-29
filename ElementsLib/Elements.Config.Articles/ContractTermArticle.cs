using System;

namespace ElementsLib.Elements.Config.Articles
{
    using SymbolCode = Module.Codes.ArticleCzCode;
    using SourceCode = UInt16;
    public class ContractTermArticle : ArticleGeneralSource
    {
        public ContractTermArticle() : base((SourceCode)SymbolCode.ARTCODE_CONTRACT_TERM)
        {

        }
    }
}
