
namespace ElementsLib
{
    using System;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Libs;
    using Common;
    using Interfaces;

    public static class ArticleSourceFactory
    {
        private const string NAME_CLASS_POSTFIX = "Article";
        private const string NAME_CLASS_PATTERN = "ARTCODE_(.*)";
        private const string NAME_SPACE_PREFIX = "ElementsLib.ModuleConfig.Articles";

        public static IArticleSource ArticleSourceFor(Assembly configAssembly, string articleName)
        {
            string targetClass = ClassNameFor(articleName);

            return GeneralFactory<IArticleSource>.InstanceFor(configAssembly, NAME_SPACE_PREFIX, targetClass);
        }

        public static string ClassNameFor(string targetName)
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
