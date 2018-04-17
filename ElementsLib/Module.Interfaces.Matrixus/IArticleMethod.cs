using System;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigRole = UInt16;
    public interface IArticleMethod : ICloneable
    {
        ConfigRole Role();
        ConfigRole[] Path();
        void SetSymbolRole(ConfigRole _role, params ConfigRole[] _path);
    }
}
