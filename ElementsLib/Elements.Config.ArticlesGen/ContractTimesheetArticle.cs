using System;

namespace ElementsLib.Elements.Config.Articles
{
    using MarkCode = Module.Codes.ArticleCzCode;
    using BodyCode = UInt16;

    using Source;
    using Module.Interfaces.Elements;

    public class ContractTimesheetArticle : ArticleGeneralSource, ICloneable
    {
        public ContractTimesheetArticle() : base((BodyCode)MarkCode.ARTCODE_CONTRACT_TIMESHEET)
        {
            SourceValues = new ContractTimesheetSource();
        }

        public ContractTimesheetArticle(ISourceValues values) : this()
        {
            ContractTimesheetSource sourceValues = values as ContractTimesheetSource;

            SourceValues = (ContractTimesheetSource)sourceValues.Clone();
        }

        public ContractTimesheetSource SourceValues { get; set; }

        public override void ImportSourceValues(ISourceValues values)
        {
            ContractTimesheetSource sourceValues = values as ContractTimesheetSource;

            SourceValues = (ContractTimesheetSource)sourceValues.Clone();
        }

        public override IArticleSource CloneSourceAndSetValues(ISourceValues values)
        {
            ContractTimesheetArticle cloneArticle = (ContractTimesheetArticle)Clone();

            cloneArticle.ImportSourceValues(values);

            return cloneArticle;
        }

        public override object Clone()
        {
            ContractTimesheetArticle cloneArticle = (ContractTimesheetArticle)this.MemberwiseClone();

            clone.InternalCode = this.InternalCode;

            return cloneArticle;
        }

    }
}
