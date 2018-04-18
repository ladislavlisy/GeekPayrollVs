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

    using Source;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class PositionTermArticle : GeneralArticle, ICloneable
    {
        public static string FACT_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT = "PositionTermArticle(2): Evaluate Results is not implemented!";

        public PositionTermArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_POSITION_TERM)
        {
            SourceValues = new PositionTermSource();
        }

        public PositionTermArticle(ISourceValues values) : this()
        {
            PositionTermSource sourceValues = values as PositionTermSource;

            SourceValues = (PositionTermSource)sourceValues.Clone();
        }

        public PositionTermSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<PositionTermSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("PositionTermSource(FACT_POSITION_TERM, 2): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            return ErrorToResults(FACT_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionTermArticle cloneArticle = (PositionTermArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
