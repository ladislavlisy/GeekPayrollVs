﻿using System;

namespace ElementsLib.Elements.Config.Results
{
    using TAmountDec = Decimal;
    using ResultCode = UInt16;

    using Module.Libs;
    using Legalist.Constants;

    public class IncomeInsSocialValue : GeneralResultValue
    {
        public WorkSocialTerms SummarizeType { get; protected set; }
        public TAmountDec IncomeRelated { get; protected set; }
        public TAmountDec IncomeExclude { get; protected set; }

        public IncomeInsSocialValue(WorkSocialTerms summarize, TAmountDec realted, TAmountDec exclude) : base((ResultCode)ArticleResultCode.RESULT_VALUE_INCOME_SUM_SOCIAL)
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