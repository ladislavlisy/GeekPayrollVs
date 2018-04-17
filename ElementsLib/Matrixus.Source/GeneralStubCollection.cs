using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Source
{
    using Module.Interfaces.Elements;

    public abstract class GeneralStubCollection<TConfig, TIndex, TValues>
        where TConfig : IArticleSource
        where TValues : ISourceValues
    {
        public GeneralStubCollection()
        {
            this.Models = new Dictionary<TIndex, TConfig>();
        }

        public IDictionary<TIndex, TConfig> Models { get; protected set; }

        public TIndex DefaultCode { get; protected set; }

        protected void ConfigureModel(IEnumerable<KeyValuePair<TIndex, TConfig>> configList)
        {
            Models = configList.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public ResultMonad.Result<TConfig, string> FindInstanceForCode(TIndex configCode)
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
            return ResultMonad.Result.Ok<TConfig, string>(baseInstance);
        }

        public abstract ResultMonad.Result<TConfig, string> CloneInstanceForCode(TIndex configCode, TValues sourceVals);

        public abstract void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory);
    }
}
