using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsLib.Module.Interfaces.Legalist;
using ElementsLib.Module.Items;

namespace ElementsLib.Legalist.Guides.Employ
{
    using BundleVersion = UInt16;

    using Operations;

    public abstract class EmployGuidesBuilder : GeneralGuides, IEmployGuidesBuilder
    {
        protected readonly Int32 __WeeklyWorkingDays;

        protected readonly Int32 __DailyWorkingHours;

        protected EmployGuidesBuilder(BundleVersion version,
            Int32 weeklyWorkingDays, Int32 dailyWorkingHours) : base(version)
		{
            __WeeklyWorkingDays = weeklyWorkingDays;

            __DailyWorkingHours = dailyWorkingHours;
        }
        public abstract Int32 WeeklyWorkingDays(Period period);

        public abstract Int32 DailyWorkingHours(Period period);

        public BundleVersion BuilderVersion()
        {
            return InternalVersion;
        }
        public IEmployGuides BuildPeriodGuides(Period period)
        {
            return new EmployGuides(period, 
                WeeklyWorkingDays(period),
                DailyWorkingHours(period));
        }
        public virtual object Clone()
        {
            EmployGuidesBuilder other = (EmployGuidesBuilder)this.MemberwiseClone();
            return other;
        }
    }
}
