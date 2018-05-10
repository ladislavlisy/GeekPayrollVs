using System;

namespace ElementsLib.Elements.Config.Results
{
    using TAmountDec = Decimal;
    using ResultCode = UInt16;

    using Module.Libs;
    using Legalist.Constants;

    public class IncomeTaxGeneralValue : GeneralResultValue
    {
        public WorkTaxingTerms SummarizeType { get; protected set; }
        public Byte StatementType { get; protected set; }
        public Byte ResidencyType { get; protected set; } 
        public TAmountDec IncomeGeneral { get; protected set; }
        public TAmountDec IncomeExclude { get; protected set; }
        public TAmountDec IncomeLolevel { get; protected set; }
        public TAmountDec IncomeAgrTask { get; protected set; }
        public TAmountDec IncomePartner { get; protected set; }

        public IncomeTaxGeneralValue(WorkTaxingTerms summarize, Byte statement, Byte residency, 
            TAmountDec general, TAmountDec exclude, TAmountDec lolevel, TAmountDec agrtask, TAmountDec partner) : base((ResultCode)ArticleResultCode.RESULT_VALUE_INCOME_SUM_TAXING)
        {
            this.SummarizeType = summarize;
            this.StatementType = statement;
            this.ResidencyType = residency;

            this.IncomeGeneral = general;
            this.IncomeExclude = exclude;
            this.IncomeLolevel = lolevel;
            this.IncomeAgrTask = agrtask;
            this.IncomePartner = partner;
        }

        public override string Description()
        {
            return string.Format("{0}: Summarize: {1}, Income Related: {2}, Income Exclude: {3}",
                Code.ToEnum<ArticleResultCode>().GetSymbol(),
                SummarizeType.GetSymbol(), IncomeGeneral.FormatAmount(), IncomeExclude.FormatAmount());
        }
    }
}