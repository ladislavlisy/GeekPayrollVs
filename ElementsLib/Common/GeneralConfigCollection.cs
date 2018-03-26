using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Common
{
    using SymbolName = String;

    public abstract class GeneralConfigCollection<T, ENUM, IDX>
    {
        public GeneralConfigCollection()
        {
            this.Models = new Dictionary<IDX, T>();
        }

        public IDictionary<IDX, T> Models { get; protected set; }

        public IDX DefaultCode { get; protected set; }

        public T InstanceFromModels(Assembly configAssembly, IDX configCode)
        {
            T modelInstance = default(T);

            if (!Models.ContainsKey(configCode))
            {
                T baseInstance = CreateInstanceForCode(configAssembly, configCode);

                modelInstance = ConfigureModel(baseInstance, configCode);
            }
            else
            {
                modelInstance = FindInstanceForCode(configCode);
            }
            return modelInstance;
        }

        public T ConfigureModel(T baseInstance, IDX configCode)
        {
            T modelInstance = baseInstance;

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

        public T FindInstanceForEnum(ENUM configIndex)
        {
            IDX configCode = GetCode(configIndex);

            T baseInstance = FindInstanceForCode(configCode);

            return baseInstance;
        }

        public T FindInstanceForCode(IDX configCode)
        {
            T baseInstance = default(T);

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

        public T CreateInstanceForCode(Assembly configAssembly, IDX configCode)
        {
            SymbolName configSymbol = GetSymbol(configCode);

            T emptyInstance = InstanceFor(configAssembly, configSymbol);

            return emptyInstance;
        }

        public T CloneInstanceForCode(IDX configCode)
        {
            T emptyInstance = FindInstanceForCode(configCode);

            return emptyInstance; //.Clone();
        }

        protected abstract IDX GetCode(ENUM configIndex);

        protected abstract SymbolName GetSymbol(IDX configCode);

        protected abstract T InstanceFor(Assembly configAssembly, SymbolName configSymbol);

    }
}
