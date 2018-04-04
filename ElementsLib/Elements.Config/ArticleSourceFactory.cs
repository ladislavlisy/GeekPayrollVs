using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace ElementsLib.Elements.Config
{
    using SymbolName = String;
    using SymbolCode = Module.Codes.ArticleCzCode;

    using SourceCode = UInt16;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourcePair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleSource>;

    using Module.Libs;
    using Module.Common;
    using Module.Interfaces.Elements;
    using Module.Codes;

    public class ArticleSourceFactory : IArticleSourceFactory
    {
        private const string NAME_CLASS_POSTFIX = "Article";
        private const string NAME_CLASS_PATTERN = "ARTCODE_(.*)";
        private const string NAME_SPACE_PREFIX = "ElementsLib.Elements.Config.Articles";

        public IEnumerable<SourcePair> CreateSourceList(Assembly configAssembly)
        {
            IList<SymbolCode> symbolList = EnumUtilsExtensions.GetAllItems<SymbolCode>().ToList();

            IEnumerable<SourceCode> configList = symbolList.Select((c) => ((SourceCode)c)).ToList();

            SourceCode backupCode = (SourceCode)SymbolCode.ARTCODE_UNKNOWN;

            IList<SourcePair> sourceList = configList.Select((c) => (new SourcePair(
                c, CreateSourceItem(configAssembly, c, backupCode)))).ToList();

            return sourceList;
        }

        protected SourcePair CreateSourcePair(Assembly configAssembly, SourceCode sourceCode, SourceCode backupCode)
        {
            SourceItem configItem = CreateSourceItem(configAssembly, sourceCode, backupCode);

            return new SourcePair(sourceCode, configItem);
        }

        public SourceItem CreateSourceItem(Assembly configAssembly, SourceCode symbolCode, SourceCode backupCode)
        {
            SymbolName sourceName = CreateSourceName(symbolCode);

            SymbolName backupName = CreateSourceName(backupCode);

            SourceItem sourceItem = ArticleSourceFor(configAssembly, sourceName, backupName);

            return sourceItem;
        }

        protected SymbolName CreateSourceName(SourceCode symbolCode)
        {
            return ArticleCodeAdapter.CreateEnum(symbolCode).GetSymbol();
        }

        protected IArticleSource ArticleSourceFor(Assembly configAssembly, SymbolName symbolName, SymbolName backupName = "")
        {
            string symbolClass = ClassNameFor(symbolName);

            string backupClass = "";
            if (backupName != "")
            {
                backupClass = ClassNameFor(backupName);
            }

            return GeneralFactory<IArticleSource>.InstanceFor(configAssembly, NAME_SPACE_PREFIX, symbolClass, backupClass);
        }

        protected string ClassNameFor(string targetName)
        {
            Regex regexObj = new Regex(NAME_CLASS_PATTERN, RegexOptions.Singleline);
            Match matchResult = regexObj.Match(targetName);
            string matchResultName = "";
            if (matchResult.Success)
            {
                GroupCollection regexCol = matchResult.Groups;
                if (regexCol.Count == 2)
                {
                    matchResultName = regexCol[1].Value;
                }
            }
            string className = matchResultName.Underscore().Camelize() + NAME_CLASS_POSTFIX;

            return className;
        }

    }
}
