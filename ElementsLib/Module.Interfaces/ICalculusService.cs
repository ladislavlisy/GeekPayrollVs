using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces
{
    using TargetPair = KeyValuePair<Elements.IArticleTarget, ResultMonad.Result<Elements.IArticleSource, string>>;
    public interface ICalculusService
    {
        void Initialize();
        void EvaluateBucket(Elements.IArticleBucket source);
        IList<TargetPair> GetEvaluationPath();
    }
}
