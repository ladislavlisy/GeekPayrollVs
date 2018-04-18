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

    public class PositionScheduleArticle : GeneralArticle, ICloneable
    {
        public static string FACT_POSITION_SCHEDULE_EXCEPTION_RESULT_NULL_TEXT = "PositionScheduleArticle(3): Evaluate Results is not implemented!";

        public PositionScheduleArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_POSITION_SCHEDULE)
        {
            SourceValues = new PositionScheduleSource();
        }

        public PositionScheduleArticle(ISourceValues values) : this()
        {
            PositionScheduleSource sourceValues = values as PositionScheduleSource;

            SourceValues = (PositionScheduleSource)sourceValues.Clone();
        }

        public PositionScheduleSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionScheduleSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("PositionScheduleSource(FACT_POSITION_SCHEDULE, 3): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(FACT_POSITION_SCHEDULE_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionScheduleArticle cloneArticle = (PositionScheduleArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
