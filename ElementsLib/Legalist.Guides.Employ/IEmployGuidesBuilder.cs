using System;

namespace ElementsLib.Legalist.Guides.Employ
{
    using BundleVersion = UInt16;

    using Module.Interfaces.Legalist;
    using Module.Items;

    public interface IEmployGuidesBuilder
    {
        BundleVersion BuilderVersion();
        IEmployGuides BuildPeriodGuides(Period period);
        Int32 WeeklyWorkingDays(Period period);
        Int32 DailyWorkingHours(Period period);
    }
}