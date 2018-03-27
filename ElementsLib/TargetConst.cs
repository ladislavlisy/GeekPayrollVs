using System;

namespace ElementsLib
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using ExtendedSeed = UInt16;

    public class TargetConst
    {
        public const ExtendedSeed TARGET_SEED_NULL = 0;
        public const ExtendedSeed TARGET_SEED_FIRST = 1;
        public const ContractCode CONTRACT_CODE_NULL = 0;
        public const PositionCode POSITION_CODE_NULL = 0;
    }
}
