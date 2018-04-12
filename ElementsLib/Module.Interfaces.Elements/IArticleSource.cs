using System;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    public interface IArticleSource : ICloneable
    {
        BodyCode Code();
        ISourceValues ExportSourceValues();
        void ImportSourceValues(ISourceValues values);
        ResultMonad.Result<IArticleSource, string> CloneSourceAndSetValues<T>(ISourceValues values) where T : class, IArticleSource;
    }
}