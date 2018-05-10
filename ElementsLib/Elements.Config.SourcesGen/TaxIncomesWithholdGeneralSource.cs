using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class TaxIncomesWithholdGeneralSource : ISourceValues, ICloneable
    {

        public TaxIncomesWithholdGeneralSource()
        {
        }

        public TaxIncomesWithholdGeneralSource()
        {
        }

        public virtual object Clone()
        {
            TaxIncomesWithholdGeneralSource cloneSource = (TaxIncomesWithholdGeneralSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
