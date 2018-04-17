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

    public class UnknownTarget : ArticleGeneralTarget, ICloneable
    {
        public static string TARGET_UNKNOWN_EXCEPTION_RESULT_NULL_TEXT = "UnknownTarget(0): Evaluate Results is not implemented!";

        public UnknownTarget() : base((ConfigCode)ConfigCodeEnum.TARGET_UNKNOWN)
        {
            SourceValues = new UnknownSource();
        }

        public UnknownTarget(ISourceValues values) : this()
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

        public override string TargetDecorateMessage(string message)
        {
            return string.Format("UnknownSource(TARGET_UNKNOWN, 0): { 0 }", message);
        }

        public override IEnumerable<ResultPack> EvaluateResults(HolderItem evalHolder, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            IEmployProfile employProfile = evalProfile.Employ();
            if (employProfile == null)
            {
                return ErrorToResults("Employ profile is null!");
            }
            return ErrorToResults(TARGET_UNKNOWN_EXCEPTION_RESULT_NULL_TEXT);
        }

        public override object Clone()
        {
            UnknownTarget cloneArticle = (UnknownTarget)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalType = this.InternalType;
            cloneArticle.InternalPath = this.InternalPath.ToList();

            return cloneArticle;
        }

    }
}
