using System;

namespace ElementsLib.Elements.Config.Results
{
    using Module.Libs;
    using ResultCode = UInt16;

    using ElementsLib.Legalist.Constants;
    public class TermFromStopPositionValue : GeneralResultValue
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateStop { get; set; }
        public WorkPositionType PositionType { get; set; }

        public TermFromStopPositionValue(DateTime? dateFrom, DateTime? dateStop, WorkPositionType positionType) : base((ResultCode)ArticleResultCode.RESULT_VALUE_FROM_STOP_POSITION)
        {
            DateFrom = dateFrom;
            DateStop = dateStop;
            PositionType = positionType;
        }
        public override string Description()
        {
            return string.Format("Date FROM: {0}, Date STOP: {1}, Position: {2}",
                DateFrom.ToString(), DateStop.ToString(), PositionType.GetSymbol());
        }
    }
}
