using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Guides.Employ
{
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Operations;

    public class EmployGuides : IEmployGuides
    {
        protected Period InternalPeriod { get; set; }

        protected readonly Int32 __WeeklyWorkingDays;

        protected readonly Int32 __DailyWorkingHours;

        public EmployGuides(Period period, Int32 weeklyWorkingDays, Int32 dailyWorkingHours)
        {
            InternalPeriod = period;

            __WeeklyWorkingDays = weeklyWorkingDays;

            __DailyWorkingHours = dailyWorkingHours;
        }

        public Int32 WeeklyWorkingDays()
        {
            return __WeeklyWorkingDays;
        }
        public Int32 DailyWorkingHours()
        {
            return __DailyWorkingHours;
        }
        public Int32 WeeklyWorkingSeconds()
        {
            return OperationsEmploy.WorkingSecondsWeekly(__WeeklyWorkingDays, __DailyWorkingHours);
        }
        public Int32 DailyWorkingSeconds()
        {
            return OperationsEmploy.WorkingSecondsDaily(__DailyWorkingHours);
        }
    }
}
