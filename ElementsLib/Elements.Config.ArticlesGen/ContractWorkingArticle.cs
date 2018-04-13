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

    public class ContractWorkingArticle : ArticleGeneralSource, ICloneable
    {
        public static string ARTCODE_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT = "ContractWorkingArticle(8): Evaluate Results is not implemented!";

        public ContractWorkingArticle() : base((BodyCode)MarkCode.ARTCODE_CONTRACT_WORKING)
        {
            SourceValues = new ContractWorkingSource();
        }

        public ContractWorkingArticle(ISourceValues values) : this()
        {
            ContractWorkingSource sourceValues = values as ContractWorkingSource;

            SourceValues = (ContractWorkingSource)sourceValues.Clone();
        }

        public ContractWorkingSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractWorkingSource>(values);
        }

        public override IEnumerable<ResultPack> EvaluateResults()
        {
            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(ARTCODE_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT) };
        }

        public override object Clone()
        {
            ContractWorkingArticle cloneArticle = (ContractWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
