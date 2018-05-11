using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class TaxBaseAdvancePartSource : ISourceValues, ICloneable
    {

        public TaxBaseAdvancePartSource()
        {
        }

        public virtual object Clone()
        {
            TaxBaseAdvancePartSource cloneSource = (TaxBaseAdvancePartSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
