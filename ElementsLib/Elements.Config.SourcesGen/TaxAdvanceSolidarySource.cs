using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class TaxAdvanceSolidarySource : ISourceValues, ICloneable
    {

        public TaxAdvanceSolidarySource()
        {
        }

        public TaxAdvanceSolidarySource()
        {
        }

        public virtual object Clone()
        {
            TaxAdvanceSolidarySource cloneSource = (TaxAdvanceSolidarySource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
