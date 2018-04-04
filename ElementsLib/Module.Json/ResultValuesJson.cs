using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Json
{
    public class PositionTimesheetResultJson
    {
        public string ScheduleLiable { get; set; }
        public string ScheduleActual { get; set; }
    }
    public class PositionWorkingResultJson
    {
        public string ScheduleWorked { get; set; }
    }
    public class PositionAbsenceResultJson
    {
        public string ScheduleAbsent { get; set; }
    }
    public class ContractTimesheetResultJson
    {
        public string ScheduleLiable { get; set; }
        public string ScheduleActual { get; set; }
    }
    public class ContractWorkingResultJson
    {
        public string ScheduleWorked { get; set; }
    }
    public class ContractAbsenceResultJson
    {
        public string ScheduleAbsent { get; set; }
    }
}
