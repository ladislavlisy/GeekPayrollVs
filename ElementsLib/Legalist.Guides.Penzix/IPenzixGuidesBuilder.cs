﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Guides.Penzix
{
    using BundleVersion = UInt16;
    using TAmountDec = Decimal;
    using TAmountInt = Int32;

    using Module.Interfaces.Legalist;
    using Module.Items;

    public interface IPenzixGuidesBuilder
    {
        BundleVersion BuilderVersion();
        IPenzixGuides BuildPeriodGuides(Period period);

        TAmountDec FactorEmployee(Period period);
    }
}
