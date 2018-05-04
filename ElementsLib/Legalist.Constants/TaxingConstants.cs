using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Constants
{
    using CONSTANTS_CODE = UInt16;

    public enum TaxingBehaviour : CONSTANTS_CODE
    {
        TAXING_NOTHING = 0,
        TAXING_ADVANCE = 1,
        TAXING_WITHHOLD = 2,
    }
}
