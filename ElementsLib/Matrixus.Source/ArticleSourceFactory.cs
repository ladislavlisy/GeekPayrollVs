using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace ElementsLib.Matrixus.Source
{
    using MarkName = String;

    using BodyCode = UInt16;
    using BodyItem = Module.Interfaces.Elements.IArticleSource;
    using BodyPair = KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleSource>;

    using Module.Libs;
    using Module.Common;
    using Module.Interfaces.Elements;
    using Module.Codes;

    public class ArticleSourceFactory : IArticleSourceFactory
    {
        private const string NAME_CLASS_POSTFIX = "Article";
        private const string NAME_CLASS_PATTERN = "ARTCODE_(.*)";
        private const string NAME_SPACE_PREFIX = "ElementsLib.Elements.Config.Articles";

        public IEnumerable<BodyPair> CreateSourceList(Assembly configAssembly)
        {
            IEnumerable<BodyCode> configList = ArticleCodeAdapter.GetSelectedCodes();

            BodyCode backupCode = ArticleCodeAdapter.GetDefaultsCode();

            IList<BodyPair> sourceList = configList.Select((c) => (new BodyPair(
                c, CreateSourceItem(configAssembly, c, backupCode)))).ToList();

            return sourceList;
        }

        protected BodyPair CreateSourcePair(Assembly configAssembly, BodyCode sourceCode, BodyCode backupCode)
        {
            BodyItem configItem = CreateSourceItem(configAssembly, sourceCode, backupCode);

            return new BodyPair(sourceCode, configItem);
        }

        public BodyItem CreateSourceItem(Assembly configAssembly, BodyCode symbolCode, BodyCode backupCode)
        {
            MarkName sourceName = CreateSourceName(symbolCode);

            MarkName backupName = CreateSourceName(backupCode);

            BodyItem sourceItem = ArticleSourceFor(configAssembly, sourceName, backupName);

            return sourceItem;
        }

        protected MarkName CreateSourceName(BodyCode symbolCode)
        {
            return ArticleCodeAdapter.CreateEnum(symbolCode).GetSymbol();
        }

        protected IArticleSource ArticleSourceFor(Assembly configAssembly, MarkName symbolName, MarkName backupName = "")
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
