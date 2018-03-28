using System;

namespace ElementsLib.ModuleConfig
{
    using ArticleCode = Codes.ArticleCzCode;

    using Interfaces;
    using Codes;

    public class GeneralArticleSource : IArticleSource
    {
        public GeneralArticleSource(ArticleCode code)
        {
            Code = code;
        }

        public ArticleCode Code { get; protected set; }

        public override string ToString()
        {
            return Code.GetSymbol();
        }
    }
}
