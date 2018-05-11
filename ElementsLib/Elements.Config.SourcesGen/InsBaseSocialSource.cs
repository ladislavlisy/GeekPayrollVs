using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsBaseSocialSource : ISourceValues, ICloneable
    {

        public InsBaseSocialSource()
        {
        }

        public InsBaseSocialSource()
        {
        }

        public virtual object Clone()
        {
            InsBaseSocialSource cloneSource = (InsBaseSocialSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
