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

    public class NamespaceArticleValuesBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceArticleValuesBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceArticleValuesBlok(string name) : base()
        {
            NamespaceName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using System;");
            WriteBaseBlokLine(writer, "using System.Collections.Generic;");
            WriteBaseBlokLine(writer, "using System.Linq;");
            WriteBaseBlokLine(writer, "using System.Text;");
            WriteBaseBlokLine(writer, "using System.Threading.Tasks;");
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
    public class ClassArticleValuesBlok : SourceBlokBase
    {
        private const string NAME_ARTICLE_POSTFIX = "Article";
        private const string NAME_SOURCES_POSTFIX = "Source";

        public ArticleCode ClassCode;

        public ArticleDefinition ClassDefs;
        public string ClassName { get; protected set; }
        public string FullClassName { get; protected set; }
        public string ValsClassName { get; protected set; }

        public ClassArticleValuesBlok(SourceBlokBase parent, ArticleCode code, ArticleDefinition defs, string name) : base(parent)
        {
            ClassCode = code;
            ClassDefs = defs;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public ClassArticleValuesBlok(ArticleCode code, ArticleDefinition defs, string name) : base()
        {
            ClassCode = code;
            ClassDefs = defs;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public override void StartBlok(StreamWriter writer)
        {
            FieldType[] usingTypes = ClassDefs.ArticleSources.Where((u) => (u.Type.ToUsingType() != "")).Select((x) => (x.Type)).Distinct().ToArray();

            foreach (var type in usingTypes)
            {
                WriteBaseBlokLine(writer, "using " + type.ToUsingType() + ";");
            }

            if (usingTypes.Length != 0)
            {
                DelimitLine(writer);
            }
            WriteBaseBlokLine(writer, "using Legalist.Constants;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Elements;");
            WriteBaseBlokLine(writer, "using Module.Json;");
            WriteBaseBlokLine(writer, "using Module.Libs;");
            WriteBaseBlokLine(writer, "using Newtonsoft.Json;");
            WriteBaseBlokLine(writer, "using Newtonsoft.Json.Converters;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + ValsClassName + " : ISourceValues, ICloneable");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            foreach (var value in ClassDefs.ArticleSources)
            {
                WriteBlokLine(writer, "public " + value.Type.ToTypeName() + " " + value.Name + " { get; set; }");
            }
            DelimitLine(writer);
            WriteBlokLine(writer, "public " + ValsClassName + "()");
            WriteBlokLine(writer, "{");
            foreach (var value in ClassDefs.ArticleSources)
            {
                WriteIndentBlokLine(writer, 1, value.Name + " = " + value.Type.ToInitValue() + ";");
            }
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteStartLine(writer, "public " + ValsClassName + "(");
            string[] constructorParams = ClassDefs.ArticleSources.Select((p) => (p.Type.ToTypeName() + " " + p.Name.Property())).ToArray();
            Write(writer, string.Join(", ", constructorParams));
            WriteLine(writer, ")");
            WriteBlokLine(writer, "{");
            foreach (var value in ClassDefs.ArticleSources)
            {
                if ((UInt16)value.Type >= 2000)
                {
                    WriteIndentBlokLine(writer, 1, value.Name + " = " + value.Name.Property() + ";");
                }
                else if ((UInt16)value.Type >= 1000)
                {
                    WriteIndentBlokLine(writer, 1, value.Name + " = " + value.Name.Property() + ".ToArray();");
                }
                else
                {
                    WriteIndentBlokLine(writer, 1, value.Name + " = " + value.Name.Property() + ";");
                }
            }
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public virtual object Clone()");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, ValsClassName + " cloneSource = (" + ValsClassName + ")this.MemberwiseClone();");
            DelimitLine(writer);
            foreach (var value in ClassDefs.ArticleSources)
            {
                if ((UInt16)value.Type >= 2000)
                {
                    WriteIndentBlokLine(writer, 1, "cloneSource."+ value.Name + " = this." + value.Name + ";");
                }
                else if ((UInt16)value.Type >= 1000)
                {
                    WriteIndentBlokLine(writer, 1, "cloneSource."+ value.Name + " = this." + value.Name + ".ToArray();");
                }
                else
                {
                    WriteIndentBlokLine(writer, 1, "cloneSource."+ value.Name + " = this." + value.Name + ";");
                }
            }
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "return cloneSource;");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
}
