using System;

namespace ElementsLib.Elements.Config.Articles
{
    using ConfigCodeEnum = Module.Codes.ArticleCodeCz;
    using ConfigCode = UInt16;
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Sources;
    using Module.Interfaces.Elements;

    public class UnknownArticle : GeneralArticle, ICloneable
    {
        public UnknownArticle() : base((ConfigRole)ConfigRoleEnum.ARTICLE_UNKNOWN)
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
            return string.Format("UnknownArticle(FACT_UNKNOWN, 0): {0}", message);
        }

        public override object Clone()
        {
            UnknownArticle cloneArticle = (UnknownArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
