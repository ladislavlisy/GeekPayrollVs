using System;

namespace ElementsLib.Elements.Config.Results
{
    using Module.Libs;
    using ResultCode = UInt16;

    using ElementsLib.Legalist.Constants;
    public class TermFromStopContractValue : GeneralResultValue
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateStop { get; set; }
        public WorkEmployTerms ContractType { get; set; }

        public TermFromStopContractValue(DateTime? dateFrom, DateTime? dateStop, WorkEmployTerms contractType) : base((ResultCode)ArticleResultCode.RESULT_VALUE_FROM_STOP_POSITION)
        {
            DateFrom = dateFrom;
            DateStop = dateStop;
            ContractType = contractType;
        }
        public override string Description()
        {
            return string.Format("Date FROM: {0}, Date STOP: {1}, Position: {2}",
                DateFrom.ToString(), DateStop.ToString(), ContractType.GetSymbol());
        }
    }
}
