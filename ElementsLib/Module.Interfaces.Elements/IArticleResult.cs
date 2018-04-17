using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    public interface IArticleResult : ICloneable
    {
        ConfigCode Code();
    }
}
