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

    public class PositionWorkingArticle : ArticleGeneralSource, ICloneable
    {
        public static string TARGET_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT = "PositionWorkingArticle(5): Evaluate Results is not implemented!";

        public PositionWorkingArticle() : base((ConfigCode)ConfigCodeEnum.TARGET_POSITION_WORKING)
        {
            SourceValues = new PositionWorkingSource();
        }

        public PositionWorkingArticle(ISourceValues values) : this()
        {
            PositionWorkingSource sourceValues = values as PositionWorkingSource;

            SourceValues = (PositionWorkingSource)sourceValues.Clone();
        }

        public PositionWorkingSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionWorkingSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("PositionWorkingSource(TARGET_POSITION_WORKING, 5): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(TARGET_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionWorkingArticle cloneArticle = (PositionWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
