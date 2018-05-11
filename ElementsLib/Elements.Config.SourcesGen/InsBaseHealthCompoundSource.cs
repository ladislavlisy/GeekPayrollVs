using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsBaseHealthCompoundSource : ISourceValues, ICloneable
    {

        public InsBaseHealthCompoundSource()
        {
        }

        public InsBaseHealthCompoundSource()
        {
        }

        public virtual object Clone()
        {
            InsBaseHealthCompoundSource cloneSource = (InsBaseHealthCompoundSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
