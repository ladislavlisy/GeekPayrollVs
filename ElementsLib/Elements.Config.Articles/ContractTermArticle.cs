using System;

namespace ElementsLib.Elements.Config.Articles
{
    using SymbolCode = Module.Codes.ArticleCzCode;
    using SourceCode = UInt16;
    using Source;
    using Module.Interfaces.Elements;

    public class ContractTermArticle : ArticleGeneralSource, ICloneable
    {
        public ContractTermArticle() : base((SourceCode)SymbolCode.ARTCODE_CONTRACT_TERM)
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
            ContractTermSource sourceValues = values as ContractTermSource;

            SourceValues = (ContractTermSource)sourceValues.Clone();
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            ContractTermArticle cloneArticle = (ContractTermArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            ContractTermArticle clone = (ContractTermArticle)this.MemberwiseClone();
            clone.InternalCode = this.InternalCode;

            return clone;
        }
    }
}
