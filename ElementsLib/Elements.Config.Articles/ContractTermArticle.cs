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
    using Concepts;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Utils;

    public class ContractTermArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "ContractTermArticle(ARTICLE_CONTRACT_TERM, 1): {0}";

        public ContractTermArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_TERM)
        {
            SourceValues = new ContractTermSource();

            InternalEvaluate = ContractTermConcept.EvaluateConcept;
        }

        public ContractTermArticle(ISourceValues values) : this()
        {
            ContractTermSource sourceValues = values as ContractTermSource;

            SourceValues = CloneUtils<ContractTermSource>.CloneOrNull(sourceValues);
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
            return string.Format(ARTICLE_DESCRIPTION_ERROR_FORMAT, message);
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
