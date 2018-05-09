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
            WriteBaseBlokLine(writer, "using ConfigBase = Module.Interfaces.Matrixus.IArticleConfigFeatures;");
            WriteBaseBlokLine(writer, "using ConfigRoleEnum = Module.Codes.ArticleRoleCz;");
            WriteBaseBlokLine(writer, "using ConfigRole = UInt16;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using TargetItem = Module.Interfaces.Elements.IArticleTarget;");
            WriteBaseBlokLine(writer, "using TargetErrs = String;");
            WriteBaseBlokLine(writer, "using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;");
            WriteBaseBlokLine(writer, "using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;");
            WriteBaseBlokLine(writer, "using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;");
            WriteBaseBlokLine(writer, "using ResultItem = Module.Interfaces.Elements.IArticleResult;");
            WriteBaseBlokLine(writer, "using ValidsPack = ResultMonad.Result<bool, string>;");
            WriteBaseBlokLine(writer, "using SourceItem = Sources." + ClassName + "Source;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "using Sources;");
            WriteBaseBlokLine(writer, "using Concepts;");
            WriteBaseBlokLine(writer, "using Legalist.Constants;");
            WriteBaseBlokLine(writer, "using Module.Items;");
            WriteBaseBlokLine(writer, "using Module.Libs;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Elements;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Legalist;");
            WriteBaseBlokLine(writer, "using Module.Interfaces.Matrixus;");
            WriteBaseBlokLine(writer, "using Utils;");
            WriteBaseBlokLine(writer, "using Results;");
            DelimitLine(writer);
            WriteBaseBlokLine(writer, "public class " + FullClassName + " : GeneralArticle, ICloneable");
            WriteBaseBlokLine(writer, "{");
        }

        public override void BlokBody(StreamWriter writer)
        {
            string CLASS_ENUM = ClassRole.GetSymbol();
            string CLASS_UINT = ((UInt16)ClassRole).ToString();

            WriteBlokLine(writer, "protected delegate IEnumerable<ResultPack> EvaluateConceptDelegate(ConfigBase evalConfig, Period evalPeriod, IPeriodProfile evalProfile, Result<EvaluateSource, string> prepValues);");
            DelimitLine(writer);
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
            WriteBlokLine(writer, "protected EvaluateConceptDelegate InternalEvaluate { get; set; }");
            DelimitLine(writer);
            WriteBlokLine(writer, "protected override IEnumerable<ResultPack> EvaluateArticleResults(TargetItem evalTarget, ConfigBase evalConfig, ISourceValues evalValues, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "if (InternalEvaluate == null)");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 2, "return EvaluateUtils.DecoratedError(ARTICLE_DESCRIPTION_ERROR_FORMAT, EXCEPTION_RESULT_NONE_TEXT);");
            WriteIndentBlokLine(writer, 1, "}");
            WriteIndentBlokLine(writer, 1, "var sourceBuilder = new EvaluateSource.SourceBuilder(evalValues);");
            WriteIndentBlokLine(writer, 1, "var resultBuilder = new EvaluateSource.ResultBuilder(evalTarget, evalResults);");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "var bundleValues = PrepareConceptValues<EvaluateSource>(sourceBuilder, resultBuilder);");
            WriteIndentBlokLine(writer, 1, "if (bundleValues.IsFailure)");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 2, "return EvaluateUtils.DecoratedError(ARTICLE_DESCRIPTION_ERROR_FORMAT, bundleValues.Error);");
            WriteIndentBlokLine(writer, 1, "}");
            WriteIndentBlokLine(writer, 1, "return InternalEvaluate(evalConfig, evalPeriod, evalProfile, bundleValues);");
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

            //WriteBlokLine(writer, "public override IArticleSource CloneSourceAndSetValues(ConfigCode configCode, ISourceValues values)");
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
            WriteIndentBlokLine(writer, 1, "cloneArticle.InternalConfig = CloneUtils<IArticleConfigFeatures>.CloneOrNull(this.InternalConfig);");
            WriteIndentBlokLine(writer, 1, "cloneArticle.InternalRole = this.InternalRole;");
            WriteIndentBlokLine(writer, 1, "cloneArticle.InternalEvaluate = this.InternalEvaluate;");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "return cloneArticle;");
            WriteBlokLine(writer, "}");
            DelimitLine(writer);
            WriteBlokLine(writer, "public class EvaluateSource");
            WriteBlokLine(writer, "{");
            WriteIndentBlokLine(writer, 1, "public EvaluateSource()");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 1, "}");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 1, "// PROPERTIES DEF");
            WriteIndentBlokLine(writer, 1, "// public XXX ZZZ { get; set; }");
            WriteIndentBlokLine(writer, 1, "// PROPERTIES DEF");
            WriteIndentBlokLine(writer, 1, "public class SourceBuilder : EvalValuesSourceBuilder<EvaluateSource>");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 2, "public SourceBuilder(ISourceValues evalValues) : base(evalValues)");
            WriteIndentBlokLine(writer, 2, "{");
            WriteIndentBlokLine(writer, 2, "}");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 2, "public override EvaluateSource GetNewValues(EvaluateSource initValues)");
            WriteIndentBlokLine(writer, 2, "{");
            WriteIndentBlokLine(writer, 3, "SourceItem conceptValues = InternalValues as SourceItem;");
            WriteIndentBlokLine(writer, 3, "if (conceptValues == null)");
            WriteIndentBlokLine(writer, 3, "{");
            WriteIndentBlokLine(writer, 4, "return ReturnFailure(initValues);");
            WriteIndentBlokLine(writer, 3, "}");
            WriteIndentBlokLine(writer, 3, "return new EvaluateSource");
            WriteIndentBlokLine(writer, 3, "{");
            WriteIndentBlokLine(writer, 4, "// PROPERTIES SET");
            WriteIndentBlokLine(writer, 4, "// PROPERTIES SET");
            WriteIndentBlokLine(writer, 3, "};");
            WriteIndentBlokLine(writer, 2, "}");
            WriteIndentBlokLine(writer, 1, "}");
            WriteIndentBlokLine(writer, 1, "public class ResultBuilder : EvalValuesResultBuilder<EvaluateSource>");
            WriteIndentBlokLine(writer, 1, "{");
            WriteIndentBlokLine(writer, 2, "public ResultBuilder(TargetItem evalTarget, IEnumerable<ResultPair> evalResults) : base(evalTarget, evalResults)");
            WriteIndentBlokLine(writer, 2, "{");
            WriteIndentBlokLine(writer, 2, "}");
            DelimitLine(writer);
            WriteIndentBlokLine(writer, 2, "public override EvaluateSource GetNewValues(EvaluateSource initValues)");
            WriteIndentBlokLine(writer, 2, "{");
            WriteIndentBlokLine(writer, 3, "// PROPERTIES SET");
            WriteIndentBlokLine(writer, 3, "// PROPERTIES SET");
            WriteIndentBlokLine(writer, 3, "return initValues;");
            WriteIndentBlokLine(writer, 2, "}");
            WriteIndentBlokLine(writer, 1, "}");
            WriteBlokLine(writer, "}");
        }

        public override void CloseBlok(StreamWriter writer)
        {
            WriteBaseBlokLine(writer, "}");
        }
    }
}
