using System;
using System.Collections.Generic;
using System.Linq;
using ResultMonad;

namespace ElementsLib.Elements.Config.Targets
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;

    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using TargetPack = ResultMonad.Result<Module.Interfaces.Matrixus.IArticleTarget, string>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Items;
    using Module.Libs;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Legalist;
    using Matrixus.Target;
    using Source;

    public class UnknownTarget : ArticleGeneralTarget, ICloneable
    {
        public static string TARGET_UNKNOWN_EXCEPTION_RESULT_NULL_TEXT = "UnknownTarget(0): Evaluate Results is not implemented!";

        public UnknownTarget() : base((ConfigCode)ConfigCodeEnum.TARGET_UNKNOWN)
        {
            SourceValues = new ArticleEmptySource();
        }

        public UnknownTarget(ISourceValues values) : this()
        {
        }

        public ArticleEmptySource SourceValues { get; set; }

        public override string TargetDecorateMessage(string message)
        {
            return string.Format("UnknownSource(TARGET_UNKNOWN, 0): { 0 }", message);
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
