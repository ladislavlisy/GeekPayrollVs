using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using BodyCode = UInt16;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Source;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Source;

    public class ContractWorkingArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT = "ContractWorkingArticle(8): Evaluate Results is not implemented!";

        public ContractWorkingArticle() : base((BodyCode)ConfigCodeEnum.ARTCODE_CONTRACT_WORKING)
        {
            SourceValues = new ContractWorkingSource();
        }

        public ContractWorkingArticle(ISourceValues values) : this()
        {
            ContractWorkingSource sourceValues = values as ContractWorkingSource;

            SourceValues = (ContractWorkingSource)sourceValues.Clone();
        }

        public ContractWorkingSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractWorkingSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("ContractWorkingSource(ARTCODE_CONTRACT_WORKING, 8): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(ARTCODE_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractWorkingArticle cloneArticle = (ContractWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
