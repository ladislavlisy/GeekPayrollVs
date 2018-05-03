using System;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using ConfigGang = UInt16;
    using ConfigRole = UInt16;
    using ConfigName = String;
    using ConfigType = UInt16;
    using ConfigBind = UInt16;
    using ConfigStub = Module.Interfaces.Elements.IArticleSource;

    public interface IArticleConfigDetail : IArticleConfigFeatures, ICloneable
    {
        ConfigName Name();
        ConfigCode[] Path();
        ConfigStub Stub();
        void SetSymbolCode(ConfigCode _code, ConfigName _name, ConfigGang _gang, ConfigType _type, ConfigBind _bind, params ConfigCode[] _path);
        void SetSymbolRole(ConfigRole _role, ConfigStub _stub);
    }
}
