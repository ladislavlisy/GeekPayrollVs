using System;

namespace ElementsLib.Elements.Config.Results
{
    using TAmount = Decimal;
    using ResultCode = UInt16;

    using Module.Libs;
    using System.Linq;
    using Module.Items.Utils;

    public class MoneyPaymentValue : GeneralResultValue
    {
        public TAmount Payment { get; protected set; }
        public MoneyPaymentValue(ResultCode code, TAmount payment) : base(code)
        {
            this.Payment = payment;
        }
        public override string Description()
        {
            string formatedValue = Payment.FormatAmount();

            return string.Format("{0}: Payment: {1}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(), formatedValue);
        }
    }
}