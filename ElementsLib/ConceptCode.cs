using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib
{
    public enum ConceptCode : UInt16
    {
        CONCEPT_UNKNOWN = 0,
        CONCEPT_CONTRACT_TERM,
        CONCEPT_POSITION_TERM,
        CONCEPT_POSITION_SCHEDULE,
        CONCEPT_POSITION_TIMESHEET,
        CONCEPT_POSITION_WORKING,
        CONCEPT_POSITION_ABSENCE,
        CONCEPT_CONTRACT_TIMESHEET,
        CONCEPT_CONTRACT_WORKING,
        CONCEPT_CONTRACT_ABSENCE,
    }
    public static class ConceptCodeExtensions
    {
        public static string GetSymbol(this ConceptCode concept)
        {
            return concept.ToString();
        }
    }
}
