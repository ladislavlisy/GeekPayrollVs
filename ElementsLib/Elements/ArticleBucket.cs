using System;
using System.Reflection;

namespace ElementsLib.Elements
{
    using MarkName = String;
    using BodyCode = UInt16;

    using TempDict = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;

    using Module.Interfaces.Elements;
    using Module.Codes;
    using Config;
    using Exceptions;

    public class ArticleBucket : AbstractArticleBucket
    {
        public ArticleBucket(TempDict templates) : base(templates)
        {
        }

        public override BodyCode GetHeadBodyCode()
        {
            return (BodyCode)ArticleCodeAdapter.CreateContractCode();
        }

        public override BodyCode GetPartBodyCode()
        {
            return (BodyCode)ArticleCodeAdapter.CreatePositionCode();
        }
    }
}
