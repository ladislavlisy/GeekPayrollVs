using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Sources;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class ContractAbsenceArticle : GeneralArticle, ICloneable
    {
        public static string FACT_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "ContractAbsenceArticle(9): Evaluate Results is not implemented!";

        public ContractAbsenceArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_ABSENCE)
        {
            SourceValues = new ContractAbsenceSource();
        }

        public ContractAbsenceArticle(ISourceValues values) : this()
        {
            ContractAbsenceSource sourceValues = values as ContractAbsenceSource;

            SourceValues = (ContractAbsenceSource)sourceValues.Clone();
        }

        public ContractAbsenceSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractAbsenceSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("ContractAbsenceSource(FACT_CONTRACT_ABSENCE, 9): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(FACT_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractAbsenceArticle cloneArticle = (ContractAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
