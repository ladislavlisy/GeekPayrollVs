using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class ContractWorkingArticle : ArticleGeneralSource, ICloneable
    {
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
            ContractWorkingSource sourceValues = values as ContractWorkingSource;

            SourceValues = (ContractWorkingSource)sourceValues.Clone();
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            ContractWorkingArticle cloneArticle = (ContractWorkingArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            ContractWorkingArticle cloneArticle = (ContractWorkingArticle)this.MemberwiseClone();

            clone.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}