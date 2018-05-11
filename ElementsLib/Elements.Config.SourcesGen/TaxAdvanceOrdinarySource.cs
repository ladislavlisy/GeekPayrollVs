using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class TaxAdvanceOrdinarySource : ISourceValues, ICloneable
    {

        public TaxAdvanceOrdinarySource()
        {
        }

        public TaxAdvanceOrdinarySource()
        {
        }

        public virtual object Clone()
        {
            TaxAdvanceOrdinarySource cloneSource = (TaxAdvanceOrdinarySource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
