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
            this.ModelPath = new List<TIndex>();

            this.Models = new Dictionary<TIndex, TConfig>();
        }

        protected IList<TIndex> ModelPath { get; set; }
        protected IDictionary<TIndex, TConfig> Models { get; set; }

        protected TIndex DefaultCode { get; set; }

        protected void ConfigureModel(IEnumerable<KeyValuePair<TIndex, TConfig>> configList)
        {
            Models = configList.ToDictionary(kv => kv.Key, kv => kv.Value);

            ModelPath = Models.Keys.ToList();
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
