using System;
using System.IO;

namespace ClazzGeneratorConsoleApp.Defs
{
    using ArticleRole = ElementsLib.Module.Codes.ArticleRoleCz;

    using ElementsLib.Module.Codes;

    public class NamespaceMethodBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceMethodBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceMethodBlok(string name) : base()
        {
            NamespaceName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using System;");
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
    public class ClassMethodBlok : SourceBlokBase
    {
        private const string NAME_METHODS_POSTFIX = "Method";

        public ArticleRole ClassCode;
        public string ClassName { get; protected set; }
        public string FullClassName { get; protected set; }

        public ClassMethodBlok(SourceBlokBase parent, ArticleRole code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
            FullClassName = name + NAME_METHODS_POSTFIX;
        }

        public ClassMethodBlok(ArticleRole code, string name) : base()
        {
            ClassCode = code;
            ClassName = name;
            FullClassName = name + NAME_METHODS_POSTFIX;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using ConfigRoleEnum = Module.Codes.ArticleRoleCz;");
            WriteBaseBlokLine(writer, "using ConfigRole = UInt16;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using Matrixus.Method;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + FullClassName + " : ArticleGeneralMethod, ICloneable");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            string CLASS_ENUM = ClassCode.GetSymbol();
            string CLASS_UINT = ((UInt16)ClassCode).ToString();

            WriteBlokLine(writer, "public static string " + CLASS_ENUM + "_EXCEPTION_RESULT_NULL_TEXT = \"" + FullClassName + "(" + CLASS_UINT + "): Evaluate Results is not implemented!\";");
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + FullClassName + "() : base((ConfigRole)ConfigRoleEnum." + CLASS_ENUM + ")");
            WriteBlokLine(writer, "{");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override string MethodDecorateMessage(string message)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "return string.Format(\"" + ClassName + "(" + CLASS_ENUM + ", " + CLASS_UINT + "): { 0 }\", message);");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public override object Clone()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, FullClassName + " cloneArticle = (" + FullClassName + ")this.MemberwiseClone();");
            DelimitLine(writer);
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
