using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Config
{
    using BundleVersion = UInt16;
    internal static class EmployPropertiesDefault
    {
        public const BundleVersion VERSION_MIN = 2000;

        public const Int32 DAYS_WORKING_WEEKLY = 5;

        public const Int32 HOURS_WORKING_DAILY = 8;
    }
    public static class EmployPropertiesVersion2018
    {
        public const BundleVersion VERSION_MIN = 2018;

        public const Int32 DAYS_WORKING_WEEKLY = EmployPropertiesDefault.DAYS_WORKING_WEEKLY;

        public const Int32 HOURS_WORKING_DAILY = EmployPropertiesDefault.HOURS_WORKING_DAILY;
    }
}
