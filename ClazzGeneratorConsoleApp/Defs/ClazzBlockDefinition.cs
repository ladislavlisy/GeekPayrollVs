using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    using ArticleCode = ElementsLib.Module.Codes.ArticleCodeCz;

    using ElementsLib.Module.Codes;

    public class NamespaceDefinitionBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceDefinitionBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceDefinitionBlok(string name) : base()
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
    public class ClassDefinitionBlok : SourceBlokBase
    {
        public ArticleCode ClassCode;
        public string ClassName { get; protected set; }

        public ClassDefinitionBlok(SourceBlokBase parent, ArticleCode code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
        }

        public ClassDefinitionBlok(ArticleCode code, string name) : base()
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
            string CLASS_ENUM = ClassCode.GetSymbol();

            WriteBlokLine(writer, "public " + ClassName + "Definition() : base(ArticleCode.TARGET_" + CLASS_ENUM + ")");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "ArticleSources = ArticleDefinition.CreateParams();");
            WriteIndentBlokLine(writer, 1, "ArticleResults = ArticleDefinition.CreateParams();");
            WriteBlokLine(writer, "}");
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
    public class ClassInstanceDefinitionBlok : SourceBlokBase
    {
        public ArticleCode ClassCode;
        public string ClassName { get; protected set; }

        public ClassInstanceDefinitionBlok(SourceBlokBase parent, ArticleCode code, string name) : base(parent)
        {
            ClassCode = code;
            ClassName = name;
        }

        public ClassInstanceDefinitionBlok(ArticleCode code, string name) : base()
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
