using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsSocialFinalSource : ISourceValues, ICloneable
    {

        public InsSocialFinalSource()
        {
        }

        public InsSocialFinalSource()
        {
        }

        public virtual object Clone()
        {
            InsSocialFinalSource cloneSource = (InsSocialFinalSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
