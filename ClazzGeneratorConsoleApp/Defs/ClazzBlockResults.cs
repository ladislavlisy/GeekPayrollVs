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

    public class NamespaceArticleResultBlok : SourceBlokBase
    {
        public string NamespaceName { get; protected set; }

        public NamespaceArticleResultBlok(SourceBlokBase parent, string name) : base(parent)
        {
            NamespaceName = name;
        }

        public NamespaceArticleResultBlok(string name) : base()
        {
            NamespaceName = name;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using System;");
            WriteBaseBlokLine(writer, "using System.Collections.Generic;");
            WriteBaseBlokLine(writer, "using System.Linq;");
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
    public class ClassArticleResultBlok : SourceBlokBase
    {
        private const string NAME_ARTICLE_POSTFIX = "Concept";
        private const string NAME_SOURCES_POSTFIX = "Source";

        public ArticleRole ClassCode;

        public ArticleDefinition ClassDefs;
        public string ClassName { get; protected set; }
        public string FullClassName { get; protected set; }
        public string ValsClassName { get; protected set; }

        public ClassArticleResultBlok(SourceBlokBase parent, ArticleRole code, ArticleDefinition defs, string name) : base(parent)
        {
            ClassCode = code;
            ClassDefs = defs;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public ClassArticleResultBlok(ArticleRole code, ArticleDefinition defs, string name) : base()
        {
            ClassCode = code;
            ClassDefs = defs;
            ClassName = name;
            FullClassName = name + NAME_ARTICLE_POSTFIX;
            ValsClassName = name + NAME_SOURCES_POSTFIX;
        }

        public override void StartBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "using ConfigCode = UInt16;");
            WriteBaseBlokLine(writer, "using ConfigBase = Module.Interfaces.Matrixus.IArticleConfigFeatures;");
            WriteBaseBlokLine(writer, "using ConfigRole = UInt16;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using TargetItem = Module.Interfaces.Elements.IArticleTarget;");
            WriteBaseBlokLine(writer, "using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;");
            WriteBaseBlokLine(writer, "using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;");
            WriteBaseBlokLine(writer, "using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;");
            WriteBaseBlokLine(writer, "using ValidsPack = ResultMonad.Result<bool, string>;");
            WriteBaseBlokLine(writer, "using MasterItem = Articles." + ClassName + "Article;");
            DelimitLine(writer);
            FieldType[] usingTypes = ClassDefs.ArticleResults.Where((u) => (u.Type.ToUsingType() != "")).Select((x) => (x.Type)).Distinct().ToArray();

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
            WriteBaseBlokLine(writer, "using Module.Interfaces.Legalist;");
            WriteBaseBlokLine(writer, "using Module.Items;");
            WriteBaseBlokLine(writer, "using Utils;");
            WriteBaseBlokLine(writer, "using Sources;");
            WriteBaseBlokLine(writer, "using Results;");
            WriteBaseBlokLine(writer, "using ResultMonad;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public static class " + FullClassName);
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            string CLASS_ENUM = ClassCode.GetSymbol();
            string CLASS_UINT = ((UInt16)ClassCode).ToString();

            WriteBlokLine(writer, "public static string CONCEPT_DESCRIPTION_ERROR_FORMAT = \"" + FullClassName + "(" + CLASS_ENUM + ", " + CLASS_UINT + "): {0}\";");
            WriteBlokLine(writer, "public static string CONCEPT_PROFILE_NULL_TEXT = \"Employ profile is null!\";");
            DelimitLine(writer);
            WriteBlokLine(writer, "public static IEnumerable<ResultPack> EvaluateConcept(ConfigBase evalConfig, Period evalPeriod, IPeriodProfile evalProfile,");
            WriteIndentBlokLine(writer, 1, "Result<MasterItem.EvaluateSource, string> prepValues)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "IEmployProfile conceptProfile = evalProfile.Employ();");
            WriteIndentBlokLine(writer, 1, "if (conceptProfile == null)");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 2, "return EvaluateUtils.DecoratedError(CONCEPT_DESCRIPTION_ERROR_FORMAT, CONCEPT_PROFILE_NULL_TEXT);");
            WriteIndentBlokLine(writer, 1, "}");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "MasterItem.EvaluateSource conceptValues = prepValues.Value;");
            WriteIndentBlokLine(writer, 1, "// EVALUATION");
            WriteIndentBlokLine(writer, 1, "// EVALUATION");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "IArticleResult conceptResult = new ArticleGeneralResult(evalConfig);");
            WriteIndentBlokLine(writer, 1, "// SET RESULT VALUES");
            WriteIndentBlokLine(writer, 1, "// SET RESULT VALUES");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "return EvaluateUtils.Results(conceptResult);");
            WriteBlokLine(writer, "}");
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
}
