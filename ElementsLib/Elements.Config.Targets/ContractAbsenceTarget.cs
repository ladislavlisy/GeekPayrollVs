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

    public class ContractAbsenceTarget : ArticleGeneralTarget, ICloneable
    {
        public static string TARGET_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "ContractAbsenceTarget(9): Evaluate Results is not implemented!";

        public ContractAbsenceTarget() : base((ConfigCode)ConfigCodeEnum.TARGET_CONTRACT_ABSENCE)
        {
            SourceValues = new ContractAbsenceSource();
        }

        public ContractAbsenceTarget(ISourceValues values) : this()
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

        public override string TargetDecorateMessage(string message)
        {
            return string.Format("ContractAbsenceSource(TARGET_CONTRACT_ABSENCE, 9): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(TARGET_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractAbsenceTarget cloneArticle = (ContractAbsenceTarget)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalType = this.InternalType;
            cloneArticle.InternalPath = this.InternalPath.ToList();

            return cloneArticle;
        }

    }
}
