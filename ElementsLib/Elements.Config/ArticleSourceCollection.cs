using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ElementsLib.Elements.Config
{
    using BodyCode = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleSource;
    using BodyVals = Module.Interfaces.Elements.ISourceValues;
    using BodyPair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleSource>;

    using Module.Codes;
    using Module.Interfaces.Elements;

    public class ArticleSourceCollection : GeneralSourceCollection<BodyItem, BodyCode, BodyVals>
    {
        public ArticleSourceCollection()
        {
            DefaultCode = ArticleCodeAdapter.GetDefaultsCode();
        }

        public override void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory)
        {
            IEnumerable<BodyPair> configTypeList = configFactory.CreateSourceList(configAssembly);

            ConfigureModel(configTypeList);
        }

        public override ResultMonad.Result<BodyItem, string> CloneInstanceForCode(BodyCode configCode, BodyVals sourceVals)
        {
            ResultMonad.Result<BodyItem, string> emptyInstance = FindInstanceForCode(configCode);

            if (emptyInstance.IsFailure)
            {
                return emptyInstance;
            }
            return emptyInstance.Value.CloneSourceAndSetValues<BodyItem>(sourceVals);
        }

    }
}
