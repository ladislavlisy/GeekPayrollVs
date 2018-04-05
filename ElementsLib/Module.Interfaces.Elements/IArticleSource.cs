using System;

namespace ElementsLib.Module.Interfaces.Elements
{
    using SourceCode = UInt16;
    public interface IArticleSource
    {
        SourceCode Code();

        ISourceValues ExportSourceValues();

        void ImportSourceValues(ISourceValues values);
        IArticleSource CloneSourceAndSetValues(ISourceValues values);
    }
}