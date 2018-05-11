using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class TaxBaseAdvanceOrdinarySource : ISourceValues, ICloneable
    {

        public TaxBaseAdvanceOrdinarySource()
        {
        }

        public TaxBaseAdvanceOrdinarySource()
        {
        }

        public virtual object Clone()
        {
            TaxBaseAdvanceOrdinarySource cloneSource = (TaxBaseAdvanceOrdinarySource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
