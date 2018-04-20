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

    public class PositionAbsenceArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "PositionAbsenceArticle(ARTICLE_POSITION_ABSENCE, 6): {0}";

        public PositionAbsenceArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_POSITION_ABSENCE)
        {
            SourceValues = new PositionAbsenceSource();
        }

        public PositionAbsenceArticle(ISourceValues values) : this()
        {
            PositionAbsenceSource sourceValues = values as PositionAbsenceSource;

            SourceValues = CloneUtils<PositionAbsenceSource>.CloneOrNull(sourceValues);
        }

        public PositionAbsenceSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionAbsenceSource>(values);
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
            PositionAbsenceArticle cloneArticle = (PositionAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
