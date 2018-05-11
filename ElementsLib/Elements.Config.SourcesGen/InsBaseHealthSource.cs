using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsBaseHealthSource : ISourceValues, ICloneable
    {

        public InsBaseHealthSource()
        {
        }

        public InsBaseHealthSource()
        {
        }

        public virtual object Clone()
        {
            InsBaseHealthSource cloneSource = (InsBaseHealthSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
