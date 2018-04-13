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

    public class PositionWorkingArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT = "PositionWorkingArticle(5): Evaluate Results is not implemented!";

        public PositionWorkingArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_WORKING)
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

        public override IEnumerable<ResultPack> EvaluateResults()
        {
            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(ARTCODE_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT) };
        }

        public override object Clone()
        {
            PositionWorkingArticle cloneArticle = (PositionWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
