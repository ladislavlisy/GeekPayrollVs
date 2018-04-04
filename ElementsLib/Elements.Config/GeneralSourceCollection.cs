using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config
{
    using SymbolName = String;

    using Module.Interfaces.Elements;

    public abstract class GeneralSourceCollection<TConfig, TIndex> : ISourceCollection<TConfig, TIndex>
    {
        public GeneralSourceCollection()
        {
            this.Models = new Dictionary<TIndex, TConfig>();
        }

        public IDictionary<TIndex, TConfig> Models { get; protected set; }

        public TIndex DefaultCode { get; protected set; }

        protected void ConfigureModel(IEnumerable<KeyValuePair<TIndex, TConfig>> configList)
        {
            Models = configList.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public TConfig FindInstanceForCode(TIndex configCode)
        {
            TConfig baseInstance = default(TConfig);

            if (Models.ContainsKey(configCode))
            {
                baseInstance = Models[configCode];
            }
            else
            {
                baseInstance = Models[DefaultCode];
            }
            return baseInstance;
        }

        public TConfig CloneInstanceForCode(TIndex configCode)
        {
            TConfig emptyInstance = FindInstanceForCode(configCode);

            return emptyInstance; //.Clone();
        }

        public abstract void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory);
    }
}
