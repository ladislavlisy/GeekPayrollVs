using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = ArticleCode;
    using TargetSeed = UInt16;

    public class TargetConst
    {
        public const TargetSeed TARGET_SEED_NULL = 0;
        public const TargetSeed TARGET_SEED_FIRST = 1;
        public const ContractCode CONTRACT_CODE_NULL = 0;
        public const PositionCode POSITION_CODE_NULL = 0;
    }
}
