using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using SymbolName = String;

    public interface IArticleCodeConfig
    {
        ConfigCode Code();
        ConfigRole Role();
        ConfigType Type();
        SymbolName Name();
        ConfigCode[] Path();
    }
}
