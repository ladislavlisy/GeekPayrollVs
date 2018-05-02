﻿using System;

namespace ElementsLib.Module.Codes
{
    using EnumCode = UInt16;
    public enum ArticleCodeCz : EnumCode
    {
        FACT_UNKNOWN = 0,
        FACT_CONTRACT_TERM,
        FACT_CONTRACT_TIMESHEET,
        FACT_CONTRACT_WORKING,
        FACT_CONTRACT_ABSENCE,
        FACT_CONTRACT_ATTEND_ITEM,
        FACT_POSITION_TERM,
        FACT_POSITION_SCHEDULE,
        FACT_POSITION_TIMESHEET,
        FACT_POSITION_WORKING,
        FACT_POSITION_ABSENCE,
        FACT_POSITION_MONTHLY_AMOUNT = 10000,
        FACT_TAX_DECLARATION,
        FACT_INS_DECLARATION_HEALTH,
        FACT_INS_DECLARATION_SOCIAL,
        FACT_TAX_INCOMES_GENERAL,
        FACT_TAX_INCOMES_ADVANCE,
        FACT_TAX_INCOMES_WITHHOLD,
        FACT_INS_INCOMES_HEALTH,
        FACT_INS_INCOMES_SOCIAL,
        FACT_TAX_ADVANCE_BASE,
        FACT_TAX_ADVANCE_HEALTH,
        FACT_TAX_ADVANCE_SOCIAL,
        FACT_TAX_ADVANCE_PART,
        FACT_TAX_SOLIDARY_BASE,
        FACT_TAX_ADVANCE,
        FACT_TAX_SOLIDARY,
        FACT_TAX_ADVANCE_FINAL,
        FACT_TAX_WITHHOLD_BASE,
        FACT_TAX_WITHHOLD_HEALTH,
        FACT_TAX_WITHHOLD_SOCIAL,
        FACT_TAX_WITHHOLD_PART,
        FACT_TAX_WITHHOLD_FINAL,
        FACT_TAX_CLAIM_PAYER,
        FACT_TAX_CLAIM_DISABILITY,
        FACT_TAX_CLAIM_STUDYING,
        FACT_TAX_CLAIM_CHILD,
        FACT_TAX_RELIEF_PAYER,
        FACT_TAX_RELIEF_CHILD,
        FACT_TAX_BONUS_CHILD,
        FACT_INS_HEALTH_BASE,
        FACT_INS_HEALTH_FINAL,
        FACT_INS_SOCIAL_BASE,
        FACT_INS_SOCIAL_FINAL,
        FACT_INCOME_GROSS,
        FACT_INCOME_NETTO
    }
    public static class ArticleCzCodeExtensions
    {
        public static string GetSymbol(this ArticleCodeCz article)
        {
            return article.ToString();
        }
    }
    public static class ArticleCzCodeUtil
    {
        public static EnumCode GetContractCode()
        {
            return (EnumCode)ArticleCodeCz.FACT_CONTRACT_TERM;
        }
        public static EnumCode GetPositionCode()
        {
            return (EnumCode)ArticleCodeCz.FACT_POSITION_TERM;
        }
    }
}
