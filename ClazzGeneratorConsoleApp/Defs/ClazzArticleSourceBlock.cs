using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    using ArticleCode = ElementsLib.Module.Codes.ArticleCzCode;

    using ElementsLib.Module.Codes;

    public class NamespaceArticleSourceBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceArticleSourceBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceArticleSourceBlok(string name) : base()
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
    public class ClassArticleSourceBlok : SourceBlokBase
    {
        private const string NAME_ARTICLE_POSTFIX = "Article";
        private const string NAME_SOURCES_POSTFIX = "Source";

        public ArticleCode ClassCode;
        public string ClassName { get; protected set; }
        public string FullClassName { get; protected set; }
        public string ValsClassName { get; protected set; }

        public ClassArticleSourceBlok(SourceBlokBase parent, ArticleCode code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public ClassArticleSourceBlok(ArticleCode code, string name) : base()
        {
            ClassCode = code;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using MarkCode = Module.Codes.ArticleCzCode;");
            WriteBaseBlokLine(writer, "using BodyCode = UInt16;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;");
            WriteBaseBlokLine(writer, "using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;");           
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using Source;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Elements;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + FullClassName + " : ArticleGeneralSource, ICloneable");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            WriteBlokLine(writer, "public static string " + ClassCode.GetSymbol() + "_EXCEPTION_RESULT_NULL_TEXT = \"" + FullClassName + "(" + ((UInt16)ClassCode).ToString() + "): Evaluate Results is not implemented!\";");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + FullClassName + "() : base((BodyCode)MarkCode." + ClassCode.GetSymbol() + ")");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "SourceValues = new " + ValsClassName + "();");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + FullClassName + "(ISourceValues values) : this()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, ValsClassName + " sourceValues = values as " + ValsClassName + ";");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "SourceValues = (" + ValsClassName + ")sourceValues.Clone();");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + ValsClassName + " SourceValues { get; set; }");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override void ImportSourceValues(ISourceValues values)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "SourceValues = SetSourceValues<" + ValsClassName + ">(values);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override IEnumerable<ResultPack> EvaluateResults()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "return new List<ResultPack>() { Result.Fail<IArticleResult, string>(" + ClassCode.GetSymbol() + "_EXCEPTION_RESULT_NULL_TEXT) };");
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
    public class DefinitionArticleBlok : SourceBlokBase
    {
        public ArticleCode ClassCode;
        public string ClassName { get; protected set; }

        public DefinitionArticleBlok(SourceBlokBase parent, ArticleCode code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
        }

        public DefinitionArticleBlok(ArticleCode code, string name) : base()
        {
            ClassCode = code;
            ClassName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using System.Collections.Generic;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + ClassName + "Definition : ArticleDefinition");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            WriteBlokLine(writer, "public " + ClassName + "Definition() : base(ArticleCode.ARTCODE_" + ClassCode.GetSymbol() + ")");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "ArticleTargets = ArticleDefinition.CreateParams();");
            WriteIndentBlokLine(writer, 1, "ArticleResults = ArticleDefinition.CreateParams();");
            WriteBlokLine(writer, "}");
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
    public class DefinitionInstanceArticleBlok : SourceBlokBase
    {
        public ArticleCode ClassCode;
        public string ClassName { get; protected set; }

        public DefinitionInstanceArticleBlok(SourceBlokBase parent, ArticleCode code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
        }

        public DefinitionInstanceArticleBlok(ArticleCode code, string name) : base()
        {
            ClassCode = code;
            ClassName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
        }

        public override void BlokBody(StreamWriter writer)
        {
            WriteBlokLine(writer, "new " + ClassName + "Definition(),");
        }

        public override void CloseBlok(StreamWriter writer)
        {
        }
    }
}
