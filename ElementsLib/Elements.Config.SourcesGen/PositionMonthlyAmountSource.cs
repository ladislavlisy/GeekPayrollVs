using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using TAmount = Decimal;

    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class PositionMonthlyAmountSource : ISourceValues, ICloneable
    {
        public TAmount MonthlyAmount { get; set; }
        public Int16 ShiftLiable { get; set; }
        public Int16 ShiftWorked { get; set; }
        public Int16 HoursLiable { get; set; }
        public Int16 HoursWorked { get; set; }

        public PositionMonthlyAmountSource()
        {
            MonthlyAmount = decimal.Zero;
            ShiftLiable = 0;
            ShiftWorked = 0;
            HoursLiable = 0;
            HoursWorked = 0;
        }

        public PositionMonthlyAmountSource(TAmount monthlyAmount, Int16 shiftLiable, Int16 shiftWorked, Int16 hoursLiable, Int16 hoursWorked)
        {
            MonthlyAmount = monthlyAmount;
            ShiftLiable = shiftLiable;
            ShiftWorked = shiftWorked;
            HoursLiable = hoursLiable;
            HoursWorked = hoursWorked;
        }

        public virtual object Clone()
        {
            PositionMonthlyAmountSource cloneSource = (PositionMonthlyAmountSource)this.MemberwiseClone();

            cloneSource.MonthlyAmount = this.MonthlyAmount;
            cloneSource.ShiftLiable = this.ShiftLiable;
            cloneSource.ShiftWorked = this.ShiftWorked;
            cloneSource.HoursLiable = this.HoursLiable;
            cloneSource.HoursWorked = this.HoursWorked;

            return cloneSource;
        }

    }
}
