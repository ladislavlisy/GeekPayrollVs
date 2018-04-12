using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class ContractTermArticle : ArticleGeneralSource, ICloneable
    {
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

        public override object Clone()
        {
            ContractTermArticle cloneArticle = (ContractTermArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
