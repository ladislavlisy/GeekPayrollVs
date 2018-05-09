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
        public Byte StatementType { get; protected set; }
        public Byte ResidencyType { get; protected set; } 
        public TAmount IncomeGeneral { get; protected set; }
        public TAmount IncomeLolevel { get; protected set; }
        public TAmount IncomeAgrTask { get; protected set; }
        public TAmount IncomePartner { get; protected set; }
        public TAmount IncomeExclude { get; protected set; }

        public IncomeTaxGeneralValue(WorkTaxingTerms summarize, Byte statement, Byte residency, 
            TAmount general, TAmount lolevel, TAmount agrtask, TAmount partner, TAmount exclude) : base((ResultCode)ArticleResultCode.RESULT_VALUE_INCOME_SUM_TAXING)
        {
            this.SummarizeType = summarize;
            this.StatementType = statement;
            this.ResidencyType = residency;

            this.IncomeGeneral = general;
            this.IncomeLolevel = lolevel;
            this.IncomeAgrTask = agrtask;
            this.IncomePartner = partner;
            this.IncomeExclude = exclude;
        }
        public override string Description()
        {
            return string.Format("{0}: Summarize: {1}, Income Related: {2}, Income Exclude: {3}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(),
                SummarizeType.GetSymbol(), IncomeGeneral.FormatAmount(), IncomeExclude.FormatAmount());
        }
    }
}