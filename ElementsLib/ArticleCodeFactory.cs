using System;

namespace ElementsLib
{
    using PayrollCode = PayrollCzCode;

    using Libs;

    public enum PayrollCzCode : UInt16
    {
        ARTCODE_UNKNOWN = 0,
        ARTCODE_CONTRACT_TERM,
        ARTCODE_POSITION_TERM,
        ARTCODE_POSITION_SCHEDULE,
        ARTCODE_POSITION_TIMESHEET,
        ARTCODE_POSITION_WORKING,
        ARTCODE_POSITION_ABSENCE,
        ARTCODE_CONTRACT_TIMESHEET,
        ARTCODE_CONTRACT_WORKING,
        ARTCODE_CONTRACT_ABSENCE,
        //ARTCODE_POSITION_MONTHLY_AMOUNT,
        //ARTCODE_TAX_DECLARATION,
        //ARTCODE_INS_HEALTH_DECLARATION,
        //ARTCODE_INS_SOCIAL_DECLARATION,
        //ARTCODE_TAX_INCOMES_GENERAL,
        //ARTCODE_TAX_INCOMES_ADVANCE,
        //ARTCODE_TAX_INCOMES_WITHHOLD,
        //ARTCODE_INS_INCOMES_HEALTH,
        //ARTCODE_INS_INCOMES_SOCIAL,
        //ARTCODE_TAX_ADVANCE_BASE,
        //ARTCODE_TAX_ADVANCE_HEALTH,
        //ARTCODE_TAX_ADVANCE_SOCIAL,
        //ARTCODE_TAX_ADVANCE_PART,
        //ARTCODE_TAX_SOLIDARY_BASE,
        //ARTCODE_TAX_ADVANCE,
        //ARTCODE_TAX_SOLIDARY,
        //ARTCODE_TAX_ADVANCE_FINAL,
        //ARTCODE_TAX_WITHHOLD_BASE,
        //ARTCODE_TAX_WITHHOLD_HEALTH,
        //ARTCODE_TAX_WITHHOLD_SOCIAL,
        //ARTCODE_TAX_WITHHOLD_PART,
        //ARTCODE_TAX_WITHHOLD_FINAL,
        //ARTCODE_TAX_CLAIM_PAYER,
        //ARTCODE_TAX_CLAIM_DISABILITY,
        //ARTCODE_TAX_CLAIM_STUDYING,
        //ARTCODE_TAX_CLAIM_CHILD,
        //ARTCODE_TAX_RELIEF_PAYER,
        //ARTCODE_TAX_RELIEF_CHILD,
        //ARTCODE_TAX_BONUS_CHILD,
        //ARTCODE_INS_HEALTH_BASE,
        //ARTCODE_INS_HEALTH_FINAL,
        //ARTCODE_INS_SOCIAL_BASE,
        //ARTCODE_INS_SOCIAL_FINAL,
        //ARTCODE_INCOME_GROSS,
        //ARTCODE_INCOME_NETTO
    }
    public static class PayrollCzCodeExtensions
    {
        public static string GetSymbol(this PayrollCzCode article)
        {
            return article.ToString();
        }
    }

    public class ArticleCodeFactory
    {
        public static PayrollCode CreateEnum(UInt16 symbolNumb)
        {
            return symbolNumb.ToEnum<PayrollCode>(GetDefaultCode());
        }
        public static PayrollCode CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<PayrollCode>(GetDefaultCode());
        }
        public static UInt16 CreateCode(UInt16 symbolNumb)
        {
            return (UInt16)symbolNumb.ToEnum<PayrollCode>(GetDefaultCode());
        }
        public static UInt16 CreateCode(string symbolName)
        {
            return (UInt16)symbolName.ToEnum<PayrollCode>(GetDefaultCode());
        }
        private static PayrollCode GetDefaultCode()
        {
            return PayrollCode.ARTCODE_UNKNOWN;
        }
    }
}
