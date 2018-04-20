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

    public class PositionTimesheetArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_DESCRIPTION_ERROR_FORMAT = "PositionTimesheetArticle(ARTICLE_POSITION_TIMESHEET, 4): {0}";

        public PositionTimesheetArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_POSITION_TIMESHEET)
        {
            SourceValues = new PositionTimesheetSource();
        }

        public PositionTimesheetArticle(ISourceValues values) : this()
        {
            PositionTimesheetSource sourceValues = values as PositionTimesheetSource;

            SourceValues = CloneUtils<PositionTimesheetSource>.CloneOrNull(sourceValues);
        }

        public PositionTimesheetSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionTimesheetSource>(values);
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
            PositionTimesheetArticle cloneArticle = (PositionTimesheetArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
