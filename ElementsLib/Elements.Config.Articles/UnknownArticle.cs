using System;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;
    using Matrixus.Source;

    public class UnknownArticle : ArticleGeneralSource, ICloneable
    {
        public UnknownArticle() : base((BodyCode)ConfigCodeEnum.ARTCODE_UNKNOWN)
        {
            SourceValues = new ArticleEmptySource();
        }

        public UnknownArticle(ISourceValues values) : this()
        {
        }

        public override void ImportSourceValues(ISourceValues values)
        {
        }

        public ArticleEmptySource SourceValues { get; set; }
        public override ISourceValues ExportSourceValues()
        {
            return SourceValues as ISourceValues;
        }

        public override string ArticleDecorateMessage(string message)
        {
            return string.Format("UnknownArticle(ARTCODE_UNKNOWN, 0): {0}", message);
        }

        public override object Clone()
        {
            UnknownArticle cloneArticle = (UnknownArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
