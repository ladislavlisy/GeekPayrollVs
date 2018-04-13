using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Source;
    using Module.Interfaces.Elements;

    public class PositionAbsenceArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_POSITION_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "PositionAbsenceArticle(6): Evaluate Results is not implemented!";

        public PositionAbsenceArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_ABSENCE)
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

        public override IEnumerable<ResultPack> EvaluateResults()
        {
            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(ARTCODE_POSITION_ABSENCE_EXCEPTION_RESULT_NULL_TEXT) };
        }

        public override object Clone()
        {
            PositionAbsenceArticle cloneArticle = (PositionAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
