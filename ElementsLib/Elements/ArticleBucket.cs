using System;
using System.Reflection;

namespace ElementsLib.Elements
{
    using SymbolName = String;
    using TargetCode = UInt16;

    using SourceDict = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;

    using Module.Interfaces.Elements;
    using Module.Codes;
    using Config;
    using Exceptions;

    public class ArticleBucket : AbstractArticleBucket
    {
        public ArticleBucket(SourceDict templates) : base(templates)
        {
        }

        public override TargetCode GetContractArticleCode()
        {
            return (TargetCode)ArticleCodeAdapter.CreateContractCode();
        }

        public override TargetCode GetPositionArticleCode()
        {
            return (TargetCode)ArticleCodeAdapter.CreatePositionCode();
        }
    }
}
