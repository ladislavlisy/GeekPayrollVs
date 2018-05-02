using System;

namespace ElementsLib.Elements.Config.Results
{
    using TDay = Byte;
    using ResultCode = UInt16;

    using Module.Libs;
    using Legalist.Constants;

    public class DeclarationTaxingValue : GeneralResultValue
    {
        public Byte StatementType { get; protected set; }
        public WorkTaxingTerms SummarizeType { get; protected set; }
        public Byte DeclaracyType { get; protected set; }
        public Byte ResidencyType { get; protected set; }

        public DeclarationTaxingValue(Byte statement, WorkTaxingTerms summarize, Byte declaracy, Byte residency) : base((ResultCode)ArticleResultCode.RESULT_VALUE_DECLARATION_TAXING)
        {
            this.StatementType = statement;
            this.SummarizeType = summarize;
            this.DeclaracyType = declaracy;
            this.ResidencyType = residency;
        }
        public override string Description()
        {
            return string.Format("{0}: Statement: {1}, Summarize: {2}, Declaration: {3}, Residency: {4}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(),
                StatementType.ToString(), SummarizeType.GetSymbol(), DeclaracyType.ToString(), ResidencyType.ToString());
        }
    }
}