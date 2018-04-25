using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using TDay = Byte;
    using TSeconds = Int32;

    using Legalist.Constants;
    using Module.Interfaces.Elements;
    using Module.Json;
    using Module.Libs;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class ContractAttendItemSource : ISourceValues, ICloneable
    {
        public Byte DayFrom { get; set; }
        public Byte DayStop { get; set; }
        public WorkDayPieceType PieceInDayFrom { get; set; }
        public WorkDayPieceType PieceInDayBetw { get; set; }
        public WorkDayPieceType PieceInDayStop { get; set; }
        public TSeconds[] HoursInDayFrom { get; set; }
        public TSeconds[] HoursInDayBetw { get; set; }
        public TSeconds[] HoursInDayStop { get; set; }

        public ContractAttendItemSource()
        {
            DayFrom = 0;
            DayStop = 0;
            PieceInDayFrom = WorkDayPieceType.WORKDAY_FULL;
            PieceInDayBetw = WorkDayPieceType.WORKDAY_FULL;
            PieceInDayStop = WorkDayPieceType.WORKDAY_FULL;
            HoursInDayFrom = new TSeconds[0];
            HoursInDayBetw = new TSeconds[0];
            HoursInDayStop = new TSeconds[0];
        }

        public ContractAttendItemSource(Byte dayFrom, Byte dayStop, WorkDayPieceType pieceInDayFrom, WorkDayPieceType pieceInDayBetw, WorkDayPieceType pieceInDayStop, TSeconds[] hoursInDayFrom, TSeconds[] hoursInDayBetw, TSeconds[] hoursInDayStop)
        {
            DayFrom = dayFrom;
            DayStop = dayStop;
            PieceInDayFrom = pieceInDayFrom;
            PieceInDayBetw = pieceInDayBetw;
            PieceInDayStop = pieceInDayStop;
            HoursInDayFrom = hoursInDayFrom.ToArray();
            HoursInDayBetw = hoursInDayBetw.ToArray();
            HoursInDayStop = hoursInDayStop.ToArray();
        }

        public virtual object Clone()
        {
            ContractAttendItemSource cloneSource = (ContractAttendItemSource)this.MemberwiseClone();

            cloneSource.DayFrom = this.DayFrom;
            cloneSource.DayStop = this.DayStop;
            cloneSource.PieceInDayFrom = this.PieceInDayFrom;
            cloneSource.PieceInDayBetw = this.PieceInDayBetw;
            cloneSource.PieceInDayStop = this.PieceInDayStop;
            cloneSource.HoursInDayFrom = this.HoursInDayFrom.ToArray();
            cloneSource.HoursInDayBetw = this.HoursInDayBetw.ToArray();
            cloneSource.HoursInDayStop = this.HoursInDayStop.ToArray();

            return cloneSource;
        }

    }
}
