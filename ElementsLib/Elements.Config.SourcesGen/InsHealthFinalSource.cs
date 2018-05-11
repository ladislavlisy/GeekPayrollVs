using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsHealthFinalSource : ISourceValues, ICloneable
    {

        public InsHealthFinalSource()
        {
        }

        public InsHealthFinalSource()
        {
        }

        public virtual object Clone()
        {
            InsHealthFinalSource cloneSource = (InsHealthFinalSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
