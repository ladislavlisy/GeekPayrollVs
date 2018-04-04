using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Json
{
    public class ContractTermSourceJson
    {
        public string DateFrom { get; set; }
        public string DateStop { get; set; }
        public string ContractType { get; set; }
    }
    public class PositionTermSourceJson
    {
        public string DateFrom { get; set; }
        public string DateStop { get; set; }
        public string PositionType { get; set; }
    }
    public class PositionScheduleSourceJson
    {
        public string ShiftLiable { get; set; }
        public string ShiftActual { get; set; }
        public string ScheduleType { get; set; }
    }
}
