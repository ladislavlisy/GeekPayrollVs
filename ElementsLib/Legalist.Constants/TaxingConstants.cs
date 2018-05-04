using System;

namespace ElementsLib.Legalist.Constants
{
    using CONSTANTS_CODE = UInt16;

    public enum TaxingBehaviour : CONSTANTS_CODE
    {
        TAXING_NOTHING = 0,
        TAXING_EXCLUDE = 1,
        TAXING_ADVANCE = 2,
        TAXING_WITHHOLD = 3,
        TAXING_PARTNER = 4,
    }
}
