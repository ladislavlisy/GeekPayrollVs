using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces
{
    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using SourcePair = KeyValuePair<Elements.IArticleHolder, ResultMonad.Result<Elements.IArticleSource, string>>;
    using ResultPair = KeyValuePair<Elements.IArticleHolder, ResultMonad.Result<Elements.IArticleResult, string>>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Legalist;
    using Items;

    public interface ICalculusService
    {
        void Initialize();
        void EvaluateStore(Elements.IArticleSourceStore source, Period evalPeriod, IPeriodProfile evalProfile);
        List<SourcePair> GetEvaluationPath();
        List<ResultPair> GetEvaluationCase();
    }
}
