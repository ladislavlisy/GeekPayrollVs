using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Source;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class ContractAbsenceArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "ContractAbsenceArticle(9): Evaluate Results is not implemented!";

        public ContractAbsenceArticle() : base((BodyCode)MarkCode.ARTCODE_CONTRACT_ABSENCE)
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

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("ContractAbsenceSource(ARTCODE_CONTRACT_ABSENCE, 9): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(ARTCODE_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractAbsenceArticle cloneArticle = (ContractAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
