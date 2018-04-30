using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    using ElementsLib.Module.Codes;
    using System.Text.RegularExpressions;

    public enum FieldType : UInt16
    {
        BYTE,
        BOOLEAN,
        DECIMAL,
        LONG,
        ULONG,
        SHORT,
        USHORT,
        TEXT,
        DATE,
        DATE_REQ,
        TIME,
        TIME_REQ,
        TDay,
        TSeconds,
        TAmount,
        TSheetSeconds = 1000,
        AWorkDayPieceType,
        WorkEmployTerms = 2000,
        WorkPositionType,
        WorkScheduleType,
        WorkDayPieceType,
    }
    public static class FieldTypeExtensions
    {
        public static string ToTypeName(this FieldType type)
        {
            switch (type)
            {
                case FieldType.TDay:
                    return "Byte";
                case FieldType.BYTE:
                    return "Byte";
                case FieldType.BOOLEAN:
                    return "Bool";
                case FieldType.DECIMAL:
                    return "Decimal";
                case FieldType.LONG:
                    return "Int32";
                case FieldType.ULONG:
                    return "UInt32";
                case FieldType.SHORT:
                    return "Int16";
                case FieldType.USHORT:
                    return "UInt16";
                case FieldType.TEXT:
                    return "String";
                case FieldType.DATE:
                    return "DateTime?";
                case FieldType.TIME:
                    return "DateTime?";
                case FieldType.DATE_REQ:
                    return "DateTime";
                case FieldType.TIME_REQ:
                    return "DateTime";
                case FieldType.TSheetSeconds:
                    return "TSeconds[]";
                case FieldType.AWorkDayPieceType:
                    return "WorkDayPieceType[]";
                default:
                    return type.ToString();
            }
        }

        public static string ToInitValue(this FieldType type)
        {
            switch (type)
            {
                case FieldType.TDay:
                    return "0";
                case FieldType.BYTE:
                    return "0";
                case FieldType.BOOLEAN:
                    return "false";
                case FieldType.DECIMAL:
                    return "0m";
                case FieldType.LONG:
                    return "0";
                case FieldType.ULONG:
                    return "0";
                case FieldType.SHORT:
                    return "0";
                case FieldType.USHORT:
                    return "0";
                case FieldType.TEXT:
                    return "";
                case FieldType.DATE:
                    return "null";
                case FieldType.TIME:
                    return "null";
                case FieldType.DATE_REQ:
                    return "new DateTime()";
                case FieldType.TIME_REQ:
                    return "new DateTime()";
                case FieldType.WorkEmployTerms:
                    return "WorkEmployTerms.WORKTERM_UNKNOWN_TYPE";
                case FieldType.WorkPositionType:
                    return "WorkPositionType.POSITION_EXCLUSIVE";
                case FieldType.WorkScheduleType:
                    return "WorkScheduleType.SCHEDULE_NORMALY_WEEK";
                case FieldType.WorkDayPieceType:
                    return "WorkDayPieceType.WORKDAY_FULL";
                case FieldType.TSeconds:
                    return "0";
                case FieldType.TSheetSeconds:
                    return "new TSeconds[0]";
                case FieldType.AWorkDayPieceType:
                    return "new WorkDayPieceType[0]";
                case FieldType.TAmount:
                    return "decimal.Zero";
                default:
                    return type.ToString();
            }
        }
        public static string ToUsingType(this FieldType type)
        {
            switch (type)
            {
                case FieldType.TDay:
                    return "TDay = Byte";
                case FieldType.TSeconds:
                    return "TSeconds = Int32";
                case FieldType.TSheetSeconds:
                    return "TSeconds = Int32";
                case FieldType.TAmount:
                    return "TAmount = Decimal";
                default:
                    return "";
            }
        }
    }
    public class ArticleParametr
    {
        public string Name { get; protected set; }
        public FieldType Type { get; protected set; }
        public ArticleRole Refer { get; protected set; }
        public ArticleParametr(string name, FieldType type)
        {
            Name = name;
            Type = type;
            Refer = ArticleRole.ARTICLE_UNKNOWN;
        }
        public ArticleParametr(string name, FieldType type, ArticleRole refer)
        {
            Name = name;
            Type = type;
            Refer = refer;
        }
    }
    public class ArticleDefinition
    {
        private const string SOURCE_CLASS_POSTFIX = "Article";
        private const string VALUES_CLASS_POSTFIX = "Source";
        private const string RESULT_CLASS_POSTFIX = "Concept";
        private const string NAME_CLASS_PATTERN = "ARTICLE_(.*)";
        public ArticleRole Article { get; protected set; }

        public string ArticleDefn { get; protected set; }
        public IList<ArticleParametr> ArticleSources { get; protected set; }
        public IList<ArticleParametr> ArticleResults { get; protected set; }

        public ArticleDefinition(ArticleRole article)
        {
            Article = article;

            ArticleSources = new List<ArticleParametr>();

            ArticleResults = new List<ArticleParametr>();
        }
        public ArticleDefinition(ArticleRole article, IList<ArticleParametr> sources, IList<ArticleParametr> results)
        {
            Article = article;

            ArticleSources = sources;

            ArticleResults = results;
        }
        public static ArticleDefinition Create(ArticleRole article, params ArticleParametr[] arg)
        {
            IList<ArticleParametr> defnSources = arg.ToList();
            IList<ArticleParametr> defnResults = new List<ArticleParametr>();

            ArticleDefinition defn = new ArticleDefinition(article, defnSources, defnResults);
            return defn;
        }
        public ArticleDefinition AddSources(params ArticleParametr[] arg)
        {
            IList<ArticleParametr> defnSources = arg.ToList();

            ArticleDefinition defn = new ArticleDefinition(this.Article, defnSources, this.ArticleResults);
            return defn;
        }
        public ArticleDefinition AddResults(params ArticleParametr[] arg)
        {
            IList<ArticleParametr> defnResults = arg.ToList();

            ArticleDefinition defn = new ArticleDefinition(this.Article, this.ArticleSources, defnResults);
            return defn;
        }
        public static IList<ArticleParametr> CreateParams(params ArticleParametr[] arg)
        {
            return arg.ToList();
        }
        public static ArticleParametr CreateParam(string name, FieldType type)
        {
            return new ArticleParametr(name, type);
        }
        public static ArticleParametr CreateRefer(string name, FieldType type, ArticleRole refer)
        {
            return new ArticleParametr(name, type, refer);
        }

        public string ClassName()
        {
            string targetName = Article.GetSymbol();

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
            string className = matchResultName.Underscore().Camelize();

            return className;
        }
        public string FullClassName()
        {
            string className = ClassName() + SOURCE_CLASS_POSTFIX;

            return className;
        }
        public string ValsClassName()
        {
            string className = ClassName() + VALUES_CLASS_POSTFIX;

            return className;
        }
        public string ResultClassName()
        {
            string className = ClassName() + RESULT_CLASS_POSTFIX;

            return className;
        }
    }
}
