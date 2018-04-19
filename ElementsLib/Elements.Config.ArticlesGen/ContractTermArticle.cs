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
    using TargetErrs = String;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Sources;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class ContractTermArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT = "ContractTermArticle(1): Evaluate Results is not implemented!";

        public ContractTermArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_TERM)
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
            return string.Format("ContractTermSource(ARTICLE_CONTRACT_TERM, 1): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(ARTICLE_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractTermArticle cloneArticle = (ContractTermArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
