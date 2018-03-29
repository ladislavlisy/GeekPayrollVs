using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;

    public interface IArticleConfig
    {
        ConfigCode Code();
        ConfigRole Role();
        ConfigCode[] Path();
    }
}
