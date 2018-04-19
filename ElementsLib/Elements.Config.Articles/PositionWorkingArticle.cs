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

    using Sources;
    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;

    public class PositionWorkingArticle : GeneralArticle, ICloneable
    {
        public static string ARTICLE_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT = "PositionWorkingArticle(5): Evaluate Results is not implemented!";

        public PositionWorkingArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_POSITION_WORKING)
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
            return string.Format("PositionWorkingSource(ARTICLE_POSITION_WORKING, 5): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(TargetItem evalTarget, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(ARTICLE_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionWorkingArticle cloneArticle = (PositionWorkingArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
