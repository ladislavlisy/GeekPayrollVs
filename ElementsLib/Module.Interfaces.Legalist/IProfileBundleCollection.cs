using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using Items;

    public interface IBundleVersionCollection
    {
        IPeriodProfile GetPeriodProfile(Period period);
    }
}
