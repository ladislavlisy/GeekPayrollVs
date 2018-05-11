using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsBaseHealthEmployeeSource : ISourceValues, ICloneable
    {

        public InsBaseHealthEmployeeSource()
        {
        }

        public InsBaseHealthEmployeeSource()
        {
        }

        public virtual object Clone()
        {
            InsBaseHealthEmployeeSource cloneSource = (InsBaseHealthEmployeeSource)this.MemberwiseClone();


            return cloneSource;
        }

    }
}
