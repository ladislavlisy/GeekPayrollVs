using System;
using System.Collections.Generic;
using ResultMonad;

namespace ElementsLib.Elements.Config.Targets
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using TargetPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleTarget, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Target;

    public class PositionTermTarget : ArticleGeneralTarget, ICloneable
    {
        public static string TARGET_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT = "PositionTermTarget(2): Evaluate Results is not implemented!";

        public PositionTermTarget() : base((ConfigCode)ConfigCodeEnum.TARGET_POSITION_TERM)
        {
            SourceValues = new PositionTermSource();
        }

        public PositionTermTarget(ISourceValues values) : this()
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

        public override string TargetDecorateMessage(string message)
        {
            return string.Format("PositionTermSource(TARGET_POSITION_TERM, 2): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(TARGET_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            PositionTermTarget cloneArticle = (PositionTermTarget)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalType = this.InternalType;
            cloneArticle.InternalPath = this.InternalPath.ToList();

            return cloneArticle;
        }

    }
}
