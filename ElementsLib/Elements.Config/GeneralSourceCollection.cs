using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config
{
    using Module.Interfaces.Elements;

    public abstract class GeneralSourceCollection<TConfig, TIndex, TValues> : ISourceCollection<TConfig, TIndex, TValues> 
        where TConfig : IArticleSource
        where TValues : ISourceValues
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

        public abstract TConfig CloneInstanceForCode(TIndex configCode, TValues sourceVals);

        public abstract void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory);
    }
}
