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

    public class PositionAbsenceArticle : ArticleGeneralSource, ICloneable
    {
        public static string TARGET_POSITION_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "PositionAbsenceArticle(6): Evaluate Results is not implemented!";

        public PositionAbsenceArticle() : base((ConfigCode)ConfigCodeEnum.TARGET_POSITION_ABSENCE)
        {
            SourceValues = new PositionAbsenceSource();
        }

        public PositionAbsenceArticle(ISourceValues values) : this()
        {
            PositionAbsenceSource sourceValues = values as PositionAbsenceSource;

            SourceValues = (PositionAbsenceSource)sourceValues.Clone();
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
            return string.Format("PositionAbsenceSource(TARGET_POSITION_ABSENCE, 6): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(TARGET_POSITION_ABSENCE_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionAbsenceArticle cloneArticle = (PositionAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
