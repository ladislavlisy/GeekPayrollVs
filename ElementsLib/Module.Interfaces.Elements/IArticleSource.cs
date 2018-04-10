using System;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    public interface IArticleSource
    {
        BodyCode Code();

        ISourceValues ExportSourceValues();

        void ImportSourceValues(ISourceValues values);
        IArticleSource CloneSourceAndSetValues(ISourceValues values);
    }
}