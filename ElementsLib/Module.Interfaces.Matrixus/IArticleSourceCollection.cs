using System;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using BodyCode = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleSource;
    using BodyVals = Module.Interfaces.Elements.ISourceValues;

    using Elements;

    public interface IArticleSourceCollection : ISourceCollection<BodyItem, BodyCode, BodyVals>
    {
    }
}
