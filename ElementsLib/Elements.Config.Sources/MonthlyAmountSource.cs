using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using TAmount = Decimal;

    using Module.Interfaces.Elements;

    public class MonthlyAmountSource : ISourceValues, ICloneable
    {
        public TAmount MonthlyAmount { get; set; }

        public MonthlyAmountSource()
        {
            MonthlyAmount = TAmount.Zero;
        }

        public MonthlyAmountSource(TAmount monthlyAmount)
        {
            MonthlyAmount = monthlyAmount;
        }

        public virtual object Clone()
        {
            MonthlyAmountSource cloneSource = (MonthlyAmountSource)this.MemberwiseClone();

            cloneSource.MonthlyAmount = (this.MonthlyAmount);

            return cloneSource;
        }

    }
}
