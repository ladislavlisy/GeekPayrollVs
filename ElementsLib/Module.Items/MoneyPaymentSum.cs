using System;

namespace ElementsLib.Module.Items
{
    using TAmount = Decimal;
    public class MoneyPaymentSum
    {
        protected TAmount InternalBalance { get; set; }
        public MoneyPaymentSum(TAmount initBalance)
        {
            InternalBalance = initBalance;
        }
        public TAmount Balance()
        {
            return InternalBalance;
        }
        public MoneyPaymentSum Aggregate(TAmount other)
        {
            return new MoneyPaymentSum(InternalBalance + other);
        }
    }
}
