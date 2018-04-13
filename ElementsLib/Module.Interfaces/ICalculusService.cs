using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces
{
    using SourcePair = KeyValuePair<Elements.IArticleTarget, ResultMonad.Result<Elements.IArticleSource, string>>;
    using ResultPair = KeyValuePair<Elements.IArticleTarget, ResultMonad.Result<Elements.IArticleResult, string>>;
    public interface ICalculusService
    {
        void Initialize();
        void EvaluateStore(Elements.IArticleSourceStore source);
        List<SourcePair> GetEvaluationPath();
        List<ResultPair> GetEvaluationCase();
    }
}
