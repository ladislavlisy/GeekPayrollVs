using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    using BodyRole = UInt16;
    using BodyType = UInt16;

    public interface IArticleConfig
    {
        BodyCode Code();
        BodyRole Role();
        BodyType Type();
        BodyCode[] Path();
    }
}
