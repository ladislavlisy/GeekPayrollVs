using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib
{
    using ExtendedCode = UInt16;
    using PayrollsCode = PayrollCzCode;
    using PayrollsName = String;

    public class ArticleBucket : AbstractArticleBucket
    {
        internal override ExtendedCode GetContractArticleCode()
        {
            return (ExtendedCode)PayrollsCode.ARTCODE_CONTRACT_TERM;
        }

        internal override ExtendedCode GetPositionArticleCode()
        {
            return (ExtendedCode)PayrollsCode.ARTCODE_POSITION_TERM;
        }

        internal override PayrollsName GetSymbol(ExtendedCode code)
        {
            return ArticleCodeFactory.CreateEnum(code).GetSymbol();
        }
    }
}
