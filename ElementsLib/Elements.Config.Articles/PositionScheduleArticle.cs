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

    public class PositionScheduleArticle : ArticleGeneralSource, ICloneable
    {
        public static string TARGET_POSITION_SCHEDULE_EXCEPTION_RESULT_NULL_TEXT = "PositionScheduleArticle(3): Evaluate Results is not implemented!";

        public PositionScheduleArticle() : base((ConfigCode)ConfigCodeEnum.TARGET_POSITION_SCHEDULE)
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
            return string.Format("PositionScheduleSource(TARGET_POSITION_SCHEDULE, 3): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(TARGET_POSITION_SCHEDULE_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionScheduleArticle cloneArticle = (PositionScheduleArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
