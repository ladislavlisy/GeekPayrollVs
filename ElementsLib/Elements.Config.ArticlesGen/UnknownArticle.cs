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
    using TargetErrs = String;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;

    using Sources;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class UnknownArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_UNKNOWN_EXCEPTION_RESULT_NULL_TEXT = "UnknownArticle(0): Evaluate Results is not implemented!";

        public UnknownArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_UNKNOWN)
        {
            SourceValues = new UnknownSource();
        }

        public UnknownArticle(ISourceValues values) : this()
        {
            UnknownSource sourceValues = values as UnknownSource;

            SourceValues = (UnknownSource)sourceValues.Clone();
        }

        public UnknownSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<UnknownSource>(values);
        }

        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("UnknownSource(ARTICLE_UNKNOWN, 0): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPair> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(ARTICLE_UNKNOWN_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            UnknownArticle cloneArticle = (UnknownArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
