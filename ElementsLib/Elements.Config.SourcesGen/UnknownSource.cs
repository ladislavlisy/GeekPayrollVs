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

    public class UnknownSource : ISourceValues, ICloneable
    {

        public UnknownSource()
        {
        }

        public UnknownSource()
        {
        }

        public virtual object Clone()
        {
            UnknownSource cloneSource = (UnknownSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
