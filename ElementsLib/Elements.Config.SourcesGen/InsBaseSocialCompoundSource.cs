using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsBaseSocialCompoundSource : ISourceValues, ICloneable
    {

        public InsBaseSocialCompoundSource()
        {
        }

        public InsBaseSocialCompoundSource()
        {
        }

        public virtual object Clone()
        {
            InsBaseSocialCompoundSource cloneSource = (InsBaseSocialCompoundSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
