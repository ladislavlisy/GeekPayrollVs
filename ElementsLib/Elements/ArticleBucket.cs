using System;
using System.Reflection;

namespace ElementsLib.Elements
{
    using SymbolName = String;
    using ConfigCode = UInt16;

    using Module.Interfaces;
    using Module.Codes;
    using Config;

    public class ArticleBucket : AbstractArticleBucket
    {
        Assembly configAssembly = typeof(ElementsModule).Assembly;
        internal override ConfigCode GetContractArticleCode()
        {
            return (ConfigCode)ArticleCodeAdapter.CreateContractCode();
        }

        internal override ConfigCode GetPositionArticleCode()
        {
            return (ConfigCode)ArticleCodeAdapter.CreatePositionCode();
        }

        internal override SymbolName GetSymbol(ConfigCode code)
        {
            return ArticleCodeAdapter.CreateEnum(code).GetSymbol();
        }

        internal override IArticleSource GetTemplateSourceForArticle(ConfigCode code)
        {
            return ArticleSourceFactory.ArticleSourceFor(configAssembly, GetSymbol(code), GetSymbol(code));
        }
    }
}
