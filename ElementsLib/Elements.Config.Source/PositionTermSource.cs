using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Source
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;
    public class PositionTermSource : ISourceValues, ICloneable
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateStop { get; set; }
        public WorkPositionType PositionType { get; set; }

        public PositionTermSource()
        {
            DateFrom = null;
            DateStop = null;
            PositionType = WorkPositionType.POSITION_EXCLUSIVE;
        }
        public PositionTermSource(DateTime? dateFrom, DateTime? dateStop, WorkPositionType termType)
        {
            DateFrom = dateFrom;
            DateStop = dateStop;
            PositionType = termType;
        }
        public virtual object Clone()
        {
            PositionTermSource clone = (PositionTermSource)this.MemberwiseClone();

            clone.DateFrom = DateFrom;
            clone.DateStop = DateStop;
            clone.PositionType = PositionType;

            return clone;
        }
    }
}
