using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    using ResultPack = ResultMonad.Result<IArticleResult, string>;
    public interface IArticleSource : ICloneable
    {
        BodyCode Code();
        ISourceValues ExportSourceValues();
        void ImportSourceValues(ISourceValues values);
        ResultMonad.Result<IArticleSource, string> CloneSourceAndSetValues<T>(ISourceValues values) where T : class, IArticleSource;
        IEnumerable<ResultPack> EvaluateResults();
    }
}