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

    public class PositionTermArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT = "PositionTermArticle(2): Evaluate Results is not implemented!";

        public PositionTermArticle() : base((BodyCode)MarkCode.ARTCODE_POSITION_TERM)
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

        public override IEnumerable<ResultPack> EvaluateResults()
        {
            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(ARTCODE_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT) };
        }

        public override object Clone()
        {
            PositionTermArticle cloneArticle = (PositionTermArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
