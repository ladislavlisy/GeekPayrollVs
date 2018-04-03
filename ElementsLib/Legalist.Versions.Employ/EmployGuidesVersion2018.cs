using System;

namespace ElementsLib.Legalist.Versions.Employ
{
    using Config;
    using Guides.Employ;
    using Module.Items;

    public class EmployGuidesVersion2018 : EmployGuidesBuilder
    {
        public EmployGuidesVersion2018() : 
            base(EmployPropertiesVersion2018.VERSION_MIN, 
                EmployPropertiesVersion2018.DAYS_WORKING_WEEKLY,
                EmployPropertiesVersion2018.HOURS_WORKING_DAILY)
        {
        }

        public override Int32 WeeklyWorkingDays(Period period)
        {
            return __WeeklyWorkingDays;
        }

        public override Int32 DailyWorkingHours(Period period)
        {
            return __DailyWorkingHours;
        }
    }
}