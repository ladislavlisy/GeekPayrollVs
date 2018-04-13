using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class UnknownArticle : ArticleGeneralSource, ICloneable
    {
        public UnknownArticle() : base((BodyCode)MarkCode.ARTCODE_UNKNOWN)
        {
        }

        public UnknownArticle(ISourceValues values) : this()
        {
        }

        public override void ImportSourceValues(ISourceValues values)
        {
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
