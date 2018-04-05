using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config
{
    using SymbolName = String;
    using SymbolCode = Module.Codes.ArticleCzCode;

    using SourceCode = UInt16;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourcePair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleSource>;

    using Module.Common;
    using Module.Interfaces;
    using System.Reflection;
    using Module.Codes;
    using Module.Libs;
    using Module.Interfaces.Elements;

    public class ArticleSourceCollection : GeneralSourceCollection<SourceItem, SourceCode, SourceVals>
    {
        public ArticleSourceCollection()
        {
            DefaultCode = (SourceCode)SymbolCode.ARTCODE_UNKNOWN;
        }

        public override void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory)
        {
            IEnumerable<SourcePair> configTypeList = configFactory.CreateSourceList(configAssembly);

            ConfigureModel(configTypeList);
        }

        public override SourceItem CloneInstanceForCode(SourceCode configCode, SourceVals sourceVals)
        {
            SourceItem emptyInstance = FindInstanceForCode(configCode);

            return emptyInstance.CloneSourceAndSetValues(sourceVals);
        }

    }
}
