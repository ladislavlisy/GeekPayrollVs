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

    public class ContractTermSource : ISourceValues
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
        public void DeserializeValues(string json)
        {
            var ImportDateTimeCoverter = new IsoDateTimeConverter() { DateTimeFormat = "d.M.yyyy" };
            var ImportEmpTermsConverter = new WorkEmployTermsConverter();

            var dataStr = JsonConvert.DeserializeObject<ContractTermSourceJson>(json);
            var dataObj = JsonConvert.DeserializeObject<ContractTermSource>(json, ImportDateTimeCoverter, ImportEmpTermsConverter);
        }
    }
}
