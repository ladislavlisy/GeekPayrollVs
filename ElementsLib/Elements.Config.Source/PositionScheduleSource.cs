using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Source
{
    using TSeconds = Int32;

    using Module.Interfaces.Elements;
    using Legalist.Constants;

    public class PositionScheduleSource : ISourceValues
    {
        public TSeconds ShiftLiable { get; private set; }
        public TSeconds ShiftActual { get; private set; }
        public WorkScheduleType ScheduleType { get; private set; }

        public PositionScheduleSource()
        {
            ShiftLiable = 0;
            ShiftActual = 0;
            ScheduleType = WorkScheduleType.SCHEDULE_NORMALY_WEEK;
        }
    }
}
