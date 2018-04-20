using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    using ElementsLib.Module.Codes;

    public class NamespaceTargetBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceTargetBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceTargetBlok(string name) : base()
        {
            NamespaceName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using System;");
            WriteBaseBlokLine(writer, "using System.Collections.Generic;");
            WriteBaseBlokLine(writer, "using ResultMonad;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "namespace " + NamespaceName);
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
    public class ClassTargetBlok : SourceBlokBase
    {
        private const string NAME_ARTICLE_POSTFIX = "Article";
        private const string NAME_SOURCES_POSTFIX = "Source";

        public ArticleCode ClassCode;
        public ArticleRole ClassRole;
        public string ClassName { get; protected set; }
        public string FullClassName { get; protected set; }
        public string ValsClassName { get; protected set; }

        public ClassTargetBlok(SourceBlokBase parent, ArticleRole code, string name) : base(parent)
        {
            ClassRole = code;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public ClassTargetBlok(ArticleRole code, string name) : base()
        {
            ClassRole = code;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using ConfigCodeEnum = Module.Codes.ArticleCodeCz;");
            WriteBaseBlokLine(writer, "using ConfigCode = UInt16;");
            WriteBaseBlokLine(writer, "using ConfigRoleEnum = Module.Codes.ArticleRoleCz;");
            WriteBaseBlokLine(writer, "using ConfigRole = UInt16;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using TargetItem = Module.Interfaces.Elements.IArticleTarget;");
            WriteBaseBlokLine(writer, "using TargetErrs = String;");
            WriteBaseBlokLine(writer, "using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;");
            WriteBaseBlokLine(writer, "using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;");
            WriteBaseBlokLine(writer, "using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;");
            WriteBaseBlokLine(writer, "using ValidsPack = ResultMonad.Result<bool, string>;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using Sources;");
            WriteBaseBlokLine(writer, "using Concepts;");
            WriteBaseBlokLine(writer, "using Module.Items;");
            WriteBaseBlokLine(writer, "using Module.Libs;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Elements;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Legalist;");
            WriteBaseBlokLine(writer, "using Utils;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + FullClassName + " : GeneralArticle, ICloneable");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            string CLASS_ENUM = ClassRole.GetSymbol();
            string CLASS_UINT = ((UInt16)ClassRole).ToString();

            WriteBlokLine(writer, "public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = \"" + FullClassName + "(" + CLASS_ENUM + ", " + CLASS_UINT + "): {0}\";");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + FullClassName + "() : base((ConfigRole)ConfigRoleEnum." + CLASS_ENUM + ")");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "SourceValues = new " + ValsClassName + "();");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "InternalEvaluate = " + ClassName + "Concept.EvaluateConcept;");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + FullClassName + "(ISourceValues values) : this()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, ValsClassName + " sourceValues = values as " + ValsClassName + ";");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "SourceValues = CloneUtils<" + ValsClassName + ">.CloneOrNull(sourceValues);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + ValsClassName + " SourceValues { get; set; }");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override void ImportSourceValues(ISourceValues values)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "SourceValues = SetSourceValues<" + ValsClassName + ">(values);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override ISourceValues ExportSourceValues()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "return SourceValues as ISourceValues;");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override string ArticleDecorateMessage(string message)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "return string.Format(ARTICLE_DESCRIPTION_ERROR_FORMAT, message);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            //DelimitLine(writer);
            //WriteBlokLine(writer, "public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)");
            //WriteBlokLine(writer, "{");
            //WriteIndentBlokLine(writer, 1, "ValidsPack validEvaluate = ValidateEvaluateIntent(evalTarget, evalPeriod, evalProfile, evalResults);");
            //WriteIndentBlokLine(writer, 1, "if (validEvaluate.IsFailure)");
            //WriteIndentBlokLine(writer, 1, "{");
            //WriteIndentBlokLine(writer, 2, "return ErrorToResults(ArticleDecorateMessage(validEvaluate.Error));");
            //WriteIndentBlokLine(writer, 1, "}");
            //WriteIndentBlokLine(writer, 1, "IEmployProfile employProfile = evalProfile.Employ();");
            //WriteIndentBlokLine(writer, 1, "if (employProfile == null)");
            //WriteIndentBlokLine(writer, 1, "{");
            //WriteIndentBlokLine(writer, 2, "return ErrorToResults(ArticleDecorateMessage(\"Employ profile is null!\"));");
            //WriteIndentBlokLine(writer, 1, "}");
            //WriteIndentBlokLine(writer, 1, "return ErrorToResults(" + CLASS_ENUM + "_EXCEPTION_RESULT_NULL_TEXT);");
            //WriteBlokLine(writer, "}");

            //WriteBlokLine(writer, "public override IArticleSource CloneSourceAndSetValues(ISourceValues values)");
            //WriteBlokLine(writer, "{");
            //WriteIndentBlokLine(writer, 1, FullClassName + " cloneArticle = (" + FullClassName + ")Clone();");
            //DelimitLine(writer);
            //WriteIndentBlokLine(writer, 1, "cloneArticle.ImportSourceValues(values);");
            //DelimitLine(writer);
            //WriteIndentBlokLine(writer, 1, "return cloneArticle;");
            //WriteBlokLine(writer, "}");
            //DelimitLine(writer);
            WriteBlokLine(writer, "public override object Clone()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, FullClassName + " cloneArticle = (" + FullClassName + ")this.MemberwiseClone();");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "cloneArticle.InternalCode = this.InternalCode;");
            WriteIndentBlokLine(writer, 1, "cloneArticle.InternalRole = this.InternalRole;");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "return cloneArticle;");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
}
