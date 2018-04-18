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

    public class ContractTimesheetArticle : GeneralArticle, ICloneable
    {
        public static string FACT_CONTRACT_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT = "ContractTimesheetArticle(7): Evaluate Results is not implemented!";

        public ContractTimesheetArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_TIMESHEET)
        {
            SourceValues = new ContractTimesheetSource();
        }

        public ContractTimesheetArticle(ISourceValues values) : this()
        {
            ContractTimesheetSource sourceValues = values as ContractTimesheetSource;

            SourceValues = (ContractTimesheetSource)sourceValues.Clone();
        }

        public ContractTimesheetSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractTimesheetSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("ContractTimesheetSource(FACT_CONTRACT_TIMESHEET, 7): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(FACT_CONTRACT_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractTimesheetArticle cloneArticle = (ContractTimesheetArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
