using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Source;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Source;

    public class ContractTermArticle : ArticleGeneralSource, ICloneable
    {
        public static string TARGET_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT = "ContractTermArticle(1): Evaluate Results is not implemented!";

        public ContractTermArticle() : base((ConfigCode)ConfigCodeEnum.TARGET_CONTRACT_TERM)
        {
            SourceValues = new ContractTermSource();
        }

        public ContractTermArticle(ISourceValues values) : this()
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

        public override string ArticleDecorateMessage(string message)
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
            //Period period;
            //IPeriodProfile : Employ()
            //uint dayTermFrom = DateFromInPeriod(period, this.DateFrom);
            //uint dayTermStop = DateFromInPeriod(period, this.DateStop);

            //SourceValues.DateFrom;
            //SourceValues.DateStop;
            //SourceValues.ContractType;

            return ErrorToResults(TARGET_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractTermArticle cloneArticle = (ContractTermArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
