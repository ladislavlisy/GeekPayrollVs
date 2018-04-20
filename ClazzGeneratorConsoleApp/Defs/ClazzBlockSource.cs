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

    public class NamespaceSourceBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceSourceBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceSourceBlok(string name) : base()
        {
            NamespaceName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using System;");
            WriteBaseBlokLine(writer, "using System.Collections.Generic;");
            WriteBaseBlokLine(writer, "using System.Linq;");
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
    public class ClassSourceBlok : SourceBlokBase
    {
        private const string NAME_ARTICLE_POSTFIX = "Target";
        private const string NAME_SOURCES_POSTFIX = "Source";

        public ArticleRole ClassCode;
        public string ClassName { get; protected set; }
        public string FullClassName { get; protected set; }
        public string ValsClassName { get; protected set; }

        public ClassSourceBlok(SourceBlokBase parent, ArticleRole code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public ClassSourceBlok(ArticleRole code, string name) : base()
        {
            ClassCode = code;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using ConfigCodeEnum = Module.Codes.ArticleCodeCz;");
            WriteBaseBlokLine(writer, "using ConfigCode = UInt16;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using TargetItem = Module.Interfaces.Elements.IArticleTarget;");
            WriteBaseBlokLine(writer, "using TargetPack = ResultMonad.Result<Module.Interfaces.Matrixus.IArticleTarget, string>;");
            WriteBaseBlokLine(writer, "using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;");
            WriteBaseBlokLine(writer, "using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;");
            WriteBaseBlokLine(writer, "using ValidsPack = ResultMonad.Result<bool, string>;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using Module.Items;");
            WriteBaseBlokLine(writer, "using Module.Libs;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Elements;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Legalist;");
            WriteBaseBlokLine(writer, "using Matrixus.Target;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + FullClassName + " : ArticleGeneralTarget, ICloneable");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            string CLASS_ENUM = ClassCode.GetSymbol();
            string CLASS_UINT = ((UInt16)ClassCode).ToString();

            WriteBlokLine(writer, "public static string " + CLASS_ENUM + "_EXCEPTION_RESULT_NULL_TEXT = \"" + FullClassName + "(" + CLASS_UINT + "): Evaluate Results is not implemented!\";");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + FullClassName + "() : base((ConfigCode)ConfigCodeEnum." + CLASS_ENUM + ")");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "SourceValues = new " + ValsClassName + "();");
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
            WriteBlokLine(writer, "public override string TargetDecorateMessage(string message)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "return string.Format(\"" + ValsClassName + "(" + CLASS_ENUM + ", " + CLASS_UINT + "): { 0 }\", message);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "IEmployProfile employProfile = evalProfile.Employ();");
            WriteIndentBlokLine(writer, 1, "if (employProfile == null)");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 2, "return ErrorToResults(ArticleDecorateMessage(\"Employ profile is null!\"));");
            WriteIndentBlokLine(writer, 1, "}");
            WriteIndentBlokLine(writer, 1, "return ErrorToResults(" + CLASS_ENUM + "_EXCEPTION_RESULT_NULL_TEXT);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);

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
