using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Common
{
    using SymbolName = String;

    public abstract class GeneralConfigCollection<TConfig, TIndex>
    {
        public GeneralConfigCollection()
        {
            this.Models = new Dictionary<TIndex, TConfig>();
        }

        public IDictionary<TIndex, TConfig> Models { get; protected set; }

        public TIndex DefaultCode { get; protected set; }

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
    }
}
