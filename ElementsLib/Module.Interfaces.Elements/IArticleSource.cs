using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using HolderItem = IArticleHolder;
    using ResultPack = ResultMonad.Result<IArticleResult, string>;

    using Items;
    using Legalist;
    public interface IArticleSource : ICloneable
    {
        ConfigCode Code();
        void ImportSourceValues(ISourceValues values);
        ISourceValues ExportSourceValues();
        ResultMonad.Result<IArticleSource, string> CloneSourceAndSetValues<T>(ISourceValues values) where T : class, IArticleSource;
        IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults);
    }
}