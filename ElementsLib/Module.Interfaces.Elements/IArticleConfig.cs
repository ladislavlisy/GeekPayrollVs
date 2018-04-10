using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    using BodyRole = UInt16;

    public interface IArticleConfig
    {
        BodyCode Code();
        BodyRole Role();
        BodyCode[] Path();
    }
}
