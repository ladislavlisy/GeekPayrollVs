using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Source
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;
    using Module.Json;
    using Module.Libs;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class ContractTermSource : ISourceValues, ICloneable
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateStop { get; set; }
        public WorkEmployTerms ContractType { get; set; }

        public ContractTermSource()
        {
            DateFrom = null;
            DateStop = null;
            ContractType = WorkEmployTerms.WORKTERM_UNKNOWN_TYPE;
        }
        public ContractTermSource(DateTime? dateFrom, DateTime? dateStop, WorkEmployTerms termType)
        {
            DateFrom = dateFrom;
            DateStop = dateStop;
            ContractType = termType;
        }

        public virtual object Clone()
        {
            ContractTermSource clone = (ContractTermSource)this.MemberwiseClone();

            clone.DateFrom = DateFrom;
            clone.DateStop = DateStop;
            clone.ContractType = ContractType;

            return clone;
        }
    }
}
