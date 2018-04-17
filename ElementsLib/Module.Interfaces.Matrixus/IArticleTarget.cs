using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;

    public interface IArticleTarget : ICloneable
    {
        ConfigCode Code();
        ConfigRole Role();
        ConfigType Type();
        ConfigCode[] Path();
        void SetSymbolCode(ConfigCode _code, ConfigType _type, params ConfigCode[] _path);
        void SetSymbolRole(ConfigRole _role);
    }
}
