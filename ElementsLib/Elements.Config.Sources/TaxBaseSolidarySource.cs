using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class TaxBaseSolidarySource : ISourceValues, ICloneable
    {

        public TaxBaseSolidarySource()
        {
        }

        public virtual object Clone()
        {
            TaxBaseSolidarySource cloneSource = (TaxBaseSolidarySource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
