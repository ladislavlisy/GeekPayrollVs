using System;

namespace ElementsLib.Elements.Config.Results
{
    using TAmountDec = Decimal;
    using ResultCode = UInt16;

    using Module.Libs;

    public class MoneyTransferIncomeValue : GeneralResultValue
    {
        public TAmountDec Payment { get; protected set; }
        public MoneyTransferIncomeValue(ResultCode code, TAmountDec payment) : base(code)
        {
            this.Payment = payment;
        }
        public override string Description()
        {
            string formatedValue = Payment.FormatAmount();

            return string.Format("{0}: Income: {1}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(), formatedValue);
        }
    }
}