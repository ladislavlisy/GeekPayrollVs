using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Source
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;
    public class PositionTermSource : ISourceValues
    {
        public DateTime? DateFrom { get; private set; }
        public DateTime? DateStop { get; private set; }
        public WorkPositionType PositionType { get; private set; }

        public PositionTermSource()
        {
            DateFrom = null;
            DateStop = null;
            PositionType = WorkPositionType.POSITION_EXCLUSIVE;
        }
    }
}
