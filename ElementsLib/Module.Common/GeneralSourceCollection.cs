using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Common
{
    using SymbolName = String;

    public abstract class GeneralSourceCollection<TConfig, TIndex>
    {
        public GeneralSourceCollection()
        {
            this.Models = new Dictionary<TIndex, TConfig>();
        }

        public IDictionary<TIndex, TConfig> Models { get; protected set; }

        public TIndex DefaultCode { get; protected set; }

        public SymbolName DefaultName { get; protected set; }


        protected void ConfigureModel(IEnumerable<KeyValuePair<TIndex, TConfig>> configList)
        {
            Models = configList.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public TConfig InstanceFromModels(Assembly configAssembly, TIndex configCode)
        {
            TConfig modelInstance = default(TConfig);

            if (Models.ContainsKey(configCode) == false)
            {
                TConfig baseInstance = CreateInstanceForCode(configAssembly, configCode);

                modelInstance = ConfigureModel(baseInstance, configCode);
            }
            else
            {
                modelInstance = FindInstanceForCode(configCode);
            }
            return modelInstance;
        }

        public TConfig ConfigureModel(TConfig baseInstance, TIndex configCode)
        {
            TConfig modelInstance = baseInstance;

            if (modelInstance != null)
            {
                Models[configCode] = modelInstance;
            }
            else if (Models.ContainsKey(configCode))
            {
                modelInstance = Models[configCode];
            }
            return modelInstance;
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

        public TConfig CreateInstanceForCode(Assembly configAssembly, TIndex configCode)
        {
            SymbolName configSymbol = GetSymbol(configCode);

            TConfig emptyInstance = InstanceFor(configAssembly, configSymbol, DefaultName);

            return emptyInstance;
        }

        public TConfig CloneInstanceForCode(TIndex configCode)
        {
            TConfig emptyInstance = FindInstanceForCode(configCode);

            return emptyInstance; //.Clone();
        }

        protected abstract SymbolName GetSymbol(TIndex configCode);

        protected abstract TConfig InstanceFor(Assembly configAssembly, SymbolName configSymbol, SymbolName defaultSymbol);
    }
}
