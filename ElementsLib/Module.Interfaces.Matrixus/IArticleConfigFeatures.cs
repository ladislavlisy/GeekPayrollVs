using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigGang = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using ConfigBind = UInt16;
    public interface IArticleConfigFeatures
    {
        ConfigCode Code();
        ConfigGang Gang();
        ConfigRole Role();
        ConfigType Type();
        ConfigBind Bind();
        void SetSymbolCode(ConfigCode _code, ConfigGang _gang, ConfigType _type, ConfigBind _bind);
        void SetSymbolRole(ConfigRole _role);
    }
}
