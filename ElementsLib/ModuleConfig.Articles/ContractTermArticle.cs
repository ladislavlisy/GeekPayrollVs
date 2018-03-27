using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.ModuleConfig.Articles
{
    using ExtendedCode = PayrollCzCode;
    public class ContractTermArticle : GeneralArticleSource
    {
        public ContractTermArticle() : base(ExtendedCode.ARTCODE_CONTRACT_TERM)
        {

        }
    }
}
