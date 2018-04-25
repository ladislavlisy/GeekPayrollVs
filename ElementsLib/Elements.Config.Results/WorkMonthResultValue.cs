using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using TSeconds = Int32;
    using ResultCode = UInt16;

    using Module.Items.Utils;

    public class WorkMonthResultValue : GeneralResultValue
    {
        public WorkMonthResultValue(ResultCode code, TSeconds[] hoursMonth) : base(code)
        {
            HoursMonth = hoursMonth.ToArray();
        }
        public TSeconds[] HoursMonth { get; protected set; }
        public override string Description()
        {
            TSeconds hoursSummary = HoursMonth.Aggregate(0, (agr, x) => (agr + x));
            string formatedMonth = string.Join("; ", HoursMonth.Take(7).Select((h) => (FormatUtils.HoursFormat(h))));
            string formatedValue = FormatUtils.HoursFormat(hoursSummary);
            return string.Format("Hours in month: {0}; First Week: {1}", formatedValue, formatedMonth);
        }
    }
}
