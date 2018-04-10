using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ElementsLib.Elements.Config
{
    using MarkName = String;
    using MarkCode = Module.Codes.ArticleCzCode;

    using BodyCode = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleSource;
    using BodyVals = Module.Interfaces.Elements.ISourceValues;
    using BodyPair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleSource>;

    using Module.Common;
    using Module.Interfaces;
    using Module.Codes;
    using Module.Libs;
    using Module.Interfaces.Elements;

    public class ArticleSourceCollection : GeneralSourceCollection<BodyItem, BodyCode, BodyVals>
    {
        public ArticleSourceCollection()
        {
            DefaultCode = (BodyCode)MarkCode.ARTCODE_UNKNOWN;
        }

        public override void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory)
        {
            IEnumerable<BodyPair> configTypeList = configFactory.CreateSourceList(configAssembly);

            ConfigureModel(configTypeList);
        }

        public override BodyItem CloneInstanceForCode(BodyCode configCode, BodyVals sourceVals)
        {
            BodyItem emptyInstance = FindInstanceForCode(configCode);

            return emptyInstance.CloneSourceAndSetValues(sourceVals);
        }

    }
}
