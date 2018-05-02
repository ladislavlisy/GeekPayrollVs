using System;

namespace ElementsLib.Elements.Config.Results
{
    using TAmount = Decimal;
    using ResultCode = UInt16;

    using Module.Libs;
    using Legalist.Constants;

    public class IncomeTaxGeneralValue : GeneralResultValue
    {
        public WorkTaxingTerms SummarizeType { get; protected set; }
        public TAmount IncomeRelated { get; protected set; }
        public TAmount IncomeExclude { get; protected set; }

        public IncomeTaxGeneralValue(WorkTaxingTerms summarize, TAmount realted, TAmount exclude) : base((ResultCode)ArticleResultCode.RESULT_VALUE_INCOME_SUM_TAXING)
        {
            this.SummarizeType = summarize;
            this.IncomeRelated = realted;
            this.IncomeExclude = exclude;
        }
        public override string Description()
        {
            return string.Format("{0}: Summarize: {1}, Income Related: {2}, Income Exclude: {3}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(),
                SummarizeType.GetSymbol(), IncomeRelated.FormatAmount(), IncomeExclude.FormatAmount());
        }
    }
}