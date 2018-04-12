using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class ContractAbsenceArticle : ArticleGeneralSource, ICloneable
    {
        public ContractAbsenceArticle() : base((BodyCode)MarkCode.ARTCODE_CONTRACT_ABSENCE)
        {
            SourceValues = new ContractAbsenceSource();
        }

        public ContractAbsenceArticle(ISourceValues values) : this()
        {
            ContractAbsenceSource sourceValues = values as ContractAbsenceSource;

            SourceValues = (ContractAbsenceSource)sourceValues.Clone();
        }

        public ContractAbsenceSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            SourceValues = SetSourceValues<ContractAbsenceSource>(values);
        }

        public override object Clone()
        {
            ContractAbsenceArticle cloneArticle = (ContractAbsenceArticle)this.MemberwiseClone();

            cloneArticle.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
