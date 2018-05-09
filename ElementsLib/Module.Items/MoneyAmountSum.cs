using System;

namespace ElementsLib.Module.Items
{
    using TAmount = Decimal;
    public class MoneyAmountSum
    {
        protected TAmount InternalBalance { get; set; }
        public MoneyAmountSum(TAmount initBalance)
        {
            InternalBalance = initBalance;
        }
        public TAmount Balance()
        {
            return InternalBalance;
        }
        public MoneyAmountSum Aggregate(TAmount other)
        {
            return new MoneyAmountSum(InternalBalance + other);
        }
    }
}
