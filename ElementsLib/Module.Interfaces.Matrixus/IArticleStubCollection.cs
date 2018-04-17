using System;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using ConfigCode = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleSource;
    using BodyVals = Module.Interfaces.Elements.ISourceValues;

    using Elements;

    public interface IArticleStubCollection : ISourceCollection<BodyItem, ConfigCode, BodyVals>
    {
    }
}
