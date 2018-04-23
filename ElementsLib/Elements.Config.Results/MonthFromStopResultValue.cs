using System;

namespace ElementsLib.Elements.Config.Results
{
    using TDay = Byte;

    using Module.Interfaces.Elements;

    internal class MonthFromStopResultValue : GeneralResultValue
    {
        public override bool IsMonthFromStopValue()
        {
            return true;
        }
        public TDay PeriodDayFrom { get; protected set; }
        public TDay PeriodDayStop { get; protected set; }


        public MonthFromStopResultValue(byte dayFrom, byte dayStop)
        {
            this.PeriodDayFrom = dayFrom;
            this.PeriodDayStop = dayStop;
        }
        public override string Description()
        {
            return string.Format("Day FROM: {0}, Day STOP: {1}", 
                PeriodDayFrom.ToString(), PeriodDayStop.ToString());
        }
    }
}