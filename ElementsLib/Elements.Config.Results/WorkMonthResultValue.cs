using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using TSeconds = Int32;

    using Module.Items.Utils;

    public class WorkMonthResultValue : GeneralResultValue
    {
        public override bool IsWorkMonthValue()
        {
            return true;
        }
        public WorkMonthResultValue(TSeconds[] hoursMonth)
        {
            HoursMonth = hoursMonth.ToArray();
        }
        public TSeconds[] HoursMonth { get; protected set; }
        public override string Description()
        {
            string formatedValue = string.Join("; ", HoursMonth.Select((h) => (FormatUtils.HoursFormat(h))));
            return string.Format("Hours in month: {0}", formatedValue);
        }
    }
}
