using System;
using System.Linq;

namespace ElementsLib.Elements.Config.Results
{
    using TSeconds = Int32;

    using Module.Items.Utils;

    public class WorkWeekResultValue : GeneralResultValue
    {
        public override bool IsWorkWeekValue()
        {
            return true;
        }
        public WorkWeekResultValue(TSeconds[] hoursWeek)
        {
            HoursWeek = hoursWeek.ToArray();
        }
        public TSeconds[] HoursWeek { get; protected set; }
        public override string Description()
        {
            string formatedValue = string.Join("; ", HoursWeek.Select((h) => (FormatUtils.HoursFormat(h))));
            return string.Format("Hours in week: {0}", formatedValue);
        }

    }
}
