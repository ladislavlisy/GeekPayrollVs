using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Elements.Config
{
    using SymbolName = String;
    using SymbolCode = Module.Codes.ArticleCzCode;

    using SourceCode = UInt16;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourcePair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleSource>;

    using Module.Common;
    using Module.Interfaces;
    using System.Reflection;
    using Module.Codes;
    using Module.Libs;

    public class ArticleSourceCollection : GeneralSourceCollection<SourceItem, SourceCode>
    {
        public ArticleSourceCollection()
        {
            DefaultCode = (SourceCode)SymbolCode.ARTCODE_UNKNOWN;

            DefaultName = SymbolCode.ARTCODE_UNKNOWN.GetSymbol();
        }

        public void InitConfigModel(Assembly configAssembly)
        {
            IList<SymbolCode> configList = EnumUtilsExtensions.GetAllItems<SymbolCode>().ToList();

            SymbolCode defaultSymbol = DefaultCode.ToEnum<SymbolCode>();

            IEnumerable<SourcePair> sourceTypeList = configList.Select((c) => (new SourcePair(
                (SourceCode)c, ArticleSourceFactory.ArticleSourceFor(configAssembly, c.GetSymbol(), defaultSymbol.GetSymbol())))).ToList();

            ConfigureModel(sourceTypeList);
        }

        protected override SourceItem InstanceFor(Assembly configAssembly, SymbolName symbolName, SymbolName holderName)
        {
            return ArticleSourceFactory.ArticleSourceFor(configAssembly, symbolName, holderName);
        }

        protected override SymbolName GetSymbol(SourceCode code)
        {
            SymbolCode symbol = ArticleCodeAdapter.CreateEnum(code);

            return symbol.GetSymbol();
        }
    }
}
