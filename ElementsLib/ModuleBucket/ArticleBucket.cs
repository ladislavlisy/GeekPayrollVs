using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsLib.ModuleConfig.Codes;

namespace ElementsLib.ModuleBucket
{
    using ConfigCode = UInt16;
    using SymbolName = String;

    public class ArticleBucket : AbstractArticleBucket
    {
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
    }
}
