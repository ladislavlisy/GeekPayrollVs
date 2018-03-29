using System;

namespace ElementsLib.Elements.Config.Articles
{
    using SymbolCode = Module.Codes.ArticleCzCode;
    using SourceCode = UInt16;
    public class PositionTermArticle : ArticleGeneralSource
    {
        public PositionTermArticle() : base((SourceCode)SymbolCode.ARTCODE_POSITION_TERM)
        {

        }
    }
}
