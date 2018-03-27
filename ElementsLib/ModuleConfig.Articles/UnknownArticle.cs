using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.ModuleConfig.Articles
{
    using ExtendedCode = PayrollCzCode;
    public class UnknownArticle : GeneralArticleSource
    {
        public UnknownArticle() : base(ExtendedCode.ARTCODE_UNKNOWN)
        {

        }
    }
}
