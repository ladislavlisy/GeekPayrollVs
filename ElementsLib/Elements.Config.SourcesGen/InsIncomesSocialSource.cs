using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;
    using Module.Json;
    using Module.Libs;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class InsIncomesSocialSource : ISourceValues, ICloneable
    {

        public InsIncomesSocialSource()
        {
        }

        public InsIncomesSocialSource()
        {
        }

        public virtual object Clone()
        {
            InsIncomesSocialSource cloneSource = (InsIncomesSocialSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
