using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Targets
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using TargetPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleTarget, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Target;

    public class ContractTermTarget : ArticleGeneralTarget, ICloneable
    {
        public static string TARGET_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT = "ContractTermTarget(1): Evaluate Results is not implemented!";

        public ContractTermTarget() : base((ConfigCode)ConfigCodeEnum.TARGET_CONTRACT_TERM)
        {
            SourceValues = new ContractTermSource();
        }

        public ContractTermTarget(ISourceValues values) : this()
        {
            ContractTermSource sourceValues = values as ContractTermSource;

            SourceValues = (ContractTermSource)sourceValues.Clone();
        }

        public ContractTermSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractTermSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string TargetDecorateMessage(string message)
        {
            return string.Format("ContractTermSource(TARGET_CONTRACT_TERM, 1): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(TARGET_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractTermTarget cloneArticle = (ContractTermTarget)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalType = this.InternalType;
            cloneArticle.InternalPath = this.InternalPath.ToList();

            return cloneArticle;
        }

    }
}
