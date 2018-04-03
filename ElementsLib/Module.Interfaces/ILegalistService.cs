using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces
{
    using Items;
    using Legalist;

    public interface ILegalistService
    {
        IPeriodProfile GetPeriodProfile(Period period);
    }
}
