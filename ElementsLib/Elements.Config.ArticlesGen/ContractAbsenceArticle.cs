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

    public class ContractAbsenceArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "ContractAbsenceArticle(ARTICLE_CONTRACT_ABSENCE, 9): {0}";

        public ContractAbsenceArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_CONTRACT_ABSENCE)
        {
            SourceValues = new ContractAbsenceSource();
        }

        public ContractAbsenceArticle(ISourceValues values) : this()
        {
            ContractAbsenceSource sourceValues = values as ContractAbsenceSource;

            SourceValues = CloneUtils<ContractAbsenceSource>.CloneOrNull(sourceValues);
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
            return string.Format(ARTICLE_DESCRIPTION_ERROR_FORMAT, message);
        }

        public override object Clone()
        {
            ContractAbsenceArticle cloneArticle = (ContractAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
