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
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ValidsPack = ResultMonad.Result<bool, string>;

    using Sources;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class ContractWorkingArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT = "ContractWorkingArticle(8): Evaluate Results is not implemented!";

        public ContractWorkingArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_WORKING)
        {
            SourceValues = new ContractWorkingSource();
        }

        public ContractWorkingArticle(ISourceValues values) : this()
        {
            ContractWorkingSource sourceValues = values as ContractWorkingSource;

            SourceValues = CloneUtils<ContractWorkingSource>.CloneOrNull(sourceValues);
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
            return string.Format("ContractWorkingSource(ARTICLE_CONTRACT_WORKING, 8): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults(ArticleDecorateMessage("Employ profile is null!"));
            }
            return ErrorToResults(ARTICLE_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            ContractWorkingArticle cloneArticle = (ContractWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
