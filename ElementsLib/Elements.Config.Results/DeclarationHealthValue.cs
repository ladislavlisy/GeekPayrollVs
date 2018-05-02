using System;

namespace ElementsLib.Elements.Config.Results
{
    using TDay = Byte;
    using ResultCode = UInt16;

    using Module.Libs;
    using Legalist.Constants;

    public class DeclarationHealthValue : GeneralResultValue
    {
        public Byte StatementType { get; protected set; }
        public WorkHealthTerms SummarizeType { get; protected set; }
        public Byte ForeignerType { get; protected set; }

        public DeclarationHealthValue(Byte statement, WorkHealthTerms summarize, Byte foreigner) : base((ResultCode)ArticleResultCode.RESULT_VALUE_DECLARATION_HEALTH)
        {
            this.StatementType = statement;
            this.SummarizeType = summarize;
            this.ForeignerType = foreigner;
        }
        public override string Description()
        {
            return string.Format("{0}: Statement: {1}, Summarize: {2}, Foreigner: {3}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(),
                StatementType.ToString(), SummarizeType.GetSymbol(), ForeignerType.ToString());
        }
    }
}