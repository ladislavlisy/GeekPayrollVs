using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config
{
    using SymbolName = String;

    using Interfaces.Matrixus;
    using Module.Interfaces.Elements;

    public abstract class GeneralConfigCollection<TConfig, TIndex> : IConfigCollection<TConfig, TIndex>
    {
        public GeneralConfigCollection()
        {
            this.ModelPath = new List<KeyValuePair<TIndex, Int32>>();

            this.Models = new Dictionary<TIndex, TConfig>();

            this.ModelResolve = new Dictionary<TIndex, IEnumerable<TIndex>>();
        }

        public IList<KeyValuePair<TIndex, Int32>> ModelPath { get; protected set; }
        protected IDictionary<TIndex, TConfig> Models { get; set; }
        protected IDictionary<TIndex, IEnumerable<TIndex>> ModelResolve { get; set; }

        protected TIndex DefaultCode { get; set; }

        protected void ConfigureModel(IEnumerable<KeyValuePair<TIndex, TConfig>> configList)
        {
            Models = configList.ToDictionary(kv => kv.Key, kv => kv.Value);

            ModelPath = Models.Keys.Select((k, i) => (new KeyValuePair<TIndex, Int32>(k, i))).ToList();
        }
        protected TConfig FindConfigByCode(TIndex configCode)
        {
            TConfig modelInstance = default(TConfig);

            if (Models.ContainsKey(configCode))
            {
                modelInstance = Models[configCode];
            }
            else
            {
                modelInstance = Models[DefaultCode];
            }
            return modelInstance;
        }

        public abstract TConfig FindArticleConfig(TIndex modelCode);
    }
}
