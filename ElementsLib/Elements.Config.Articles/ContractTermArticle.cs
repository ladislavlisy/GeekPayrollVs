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
    using Module.Items;
    using Module.Interfaces.Legalist;
    using Module.Libs;

    public class ContractTermArticle : ArticleGeneralSource, ICloneable
    {
        public static string EXCEPTION_ARTICLE_RESULT_NULL_TEXT = "ContractTermArticle: Evaluate Results is not implemented!";
        public ContractTermArticle() : base((BodyCode)MarkCode.ARTCODE_CONTRACT_TERM)
        {
            SourceValues = new ContractTermSource();
        }

        public ContractTermArticle(ISourceValues values) : this()
        {
            ContractTermSource sourceValues = values as ContractTermSource;

            SourceValues = (ContractTermSource)sourceValues.Clone();
        }

        public ContractTermSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractTermSource>(values);
        }

        public override IEnumerable<ResultPack> EvaluateResults()
        {
            IEmployProfile employProfile = null;
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            //Period period;
            //IPeriodProfile : Employ()
            //uint dayTermFrom = DateFromInPeriod(period, this.DateFrom);
            //uint dayTermStop = DateFromInPeriod(period, this.DateStop);

            //SourceValues.DateFrom;
            //SourceValues.DateStop;
            //SourceValues.ContractType;

            return new List<ResultPack>() { Result.Fail<IArticleResult, string>(EXCEPTION_ARTICLE_RESULT_NULL_TEXT) };
        }

        public override object Clone()
        {
            ContractTermArticle cloneArticle = (ContractTermArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
