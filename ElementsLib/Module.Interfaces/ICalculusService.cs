﻿using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces
{
    using TargetPair = KeyValuePair<Elements.IArticleTarget, Elements.IArticleSource>;
    public interface ICalculusService
    {
        void Initialize();
        void EvaluateBucket(Elements.IArticleBucket source);
        IList<TargetPair> GetEvaluationPath();
    }
}
