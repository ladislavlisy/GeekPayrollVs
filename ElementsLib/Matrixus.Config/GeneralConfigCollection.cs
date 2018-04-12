﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config
{
    using SymbolName = String;

    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;

    public abstract class GeneralConfigCollection<TConfig, TIndex> : IConfigCollection<TConfig, TIndex>
    {
        public GeneralConfigCollection()
        {
            this.InternalModelPath = new List<KeyValuePair<TIndex, Int32>>();

            this.InternalModels = new Dictionary<TIndex, TConfig>();

            this.InternalModelResolve = new Dictionary<TIndex, IEnumerable<TIndex>>();
        }

        protected IList<KeyValuePair<TIndex, Int32>> InternalModelPath { get; set; }
        protected IDictionary<TIndex, TConfig> InternalModels { get; set; }
        protected IDictionary<TIndex, IEnumerable<TIndex>> InternalModelResolve { get; set; }

        protected TIndex DefaultCode { get; set; }

        protected void ConfigureModel(IEnumerable<KeyValuePair<TIndex, TConfig>> configList)
        {
            InternalModels = configList.ToDictionary(kv => kv.Key, kv => kv.Value);

            InternalModelPath = InternalModels.Keys.Select((k, i) => (new KeyValuePair<TIndex, Int32>(k, i))).ToList();
        }
        protected TConfig FindConfigByCode(TIndex configCode)
        {
            TConfig modelInstance = default(TConfig);

            if (InternalModels.ContainsKey(configCode))
            {
                modelInstance = InternalModels[configCode];
            }
            else
            {
                modelInstance = InternalModels[DefaultCode];
            }
            return modelInstance;
        }

        public abstract void InitConfigModel(IArticleConfigFactory configFactory);
        public abstract TConfig FindArticleConfig(TIndex modelCode);
        public abstract IEnumerable<IArticleTarget> GetTargets(IEnumerable<IArticleTarget> targetsInit, TIndex headCode, TIndex partCode);

        public IList<KeyValuePair<TIndex, Int32>> ModelPath()
        {
            return InternalModelPath.ToList();
        }
    }
}
