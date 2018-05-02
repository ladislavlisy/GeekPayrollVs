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

    public class InsIncomesHealthSource : ISourceValues, ICloneable
    {

        public InsIncomesHealthSource()
        {
        }

        public InsIncomesHealthSource()
        {
        }

        public virtual object Clone()
        {
            InsIncomesHealthSource cloneSource = (InsIncomesHealthSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
