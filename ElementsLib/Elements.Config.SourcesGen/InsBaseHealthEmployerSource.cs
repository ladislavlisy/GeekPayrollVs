using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsBaseHealthEmployerSource : ISourceValues, ICloneable
    {

        public InsBaseHealthEmployerSource()
        {
        }

        public InsBaseHealthEmployerSource()
        {
        }

        public virtual object Clone()
        {
            InsBaseHealthEmployerSource cloneSource = (InsBaseHealthEmployerSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
