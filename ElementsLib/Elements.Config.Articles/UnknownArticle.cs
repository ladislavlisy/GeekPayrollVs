using System;

namespace ElementsLib.Elements.Config.Articles
{
    using SymbolCode = Module.Codes.ArticleCzCode;
    using SourceCode = UInt16;
    public class UnknownArticle : ArticleGeneralSource
    {
        public UnknownArticle() : base((SourceCode)SymbolCode.ARTCODE_UNKNOWN)
        {

        }
    }
}
