using System;

namespace ElementsLib.Elements.Config.Results
{
    using TDay = Byte;
    using ResultCode = UInt16;

    public class MonthFromStopResultValue : GeneralResultValue
    {
        public TDay PeriodDayFrom { get; protected set; }
        public TDay PeriodDayStop { get; protected set; }

        public MonthFromStopResultValue(byte dayFrom, byte dayStop) : base((ResultCode)ArticleResultCode.RESULT_VALUE_MONTH_FROM_STOP)
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