using ElementsLib.Module.Interfaces.Matrixus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Calculus
{
    using SymbolUtil = Module.Codes.ArticleCzCodeUtil;

    public class SimpleCalculusService : CalculusService
    {
        public SimpleCalculusService(IArticleConfigProfile configProfile) : base(configProfile)
        {
            ModuleAssembly = typeof(CalculusService).Assembly;

            ContractCode = SymbolUtil.GetContractCode();

            PositionCode = SymbolUtil.GetPositionCode();
        }

        public void InitializeService()
        {
            Initialize();
        }
    }
}
