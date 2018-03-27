namespace ElementsLib
{
    using PayrollRole = PayrollCzRole;

    using System;
    using Libs;
    using Interfaces;

    public enum PayrollCzRole : UInt16
    {
        ARTROLE_UNKNOWN = 0,
        ARTROLE_CONTRACT_TERM,
        ARTROLE_POSITION_TERM,
        ARTROLE_POSITION_SCHEDULE,
        ARTROLE_POSITION_TIMESHEET,
        ARTROLE_POSITION_WORKING,
        ARTROLE_POSITION_ABSENCE,
        ARTROLE_CONTRACT_TIMESHEET,
        ARTROLE_CONTRACT_WORKING,
        ARTROLE_CONTRACT_ABSENCE,
        //ARTROLE_POSITION_MONTHLY_AMOUNT,
        //ARTROLE_TAX_DECLARATION,
        //ARTROLE_INS_HEALTH_DECLARATION,
        //ARTROLE_INS_SOCIAL_DECLARATION,
        //ARTROLE_TAX_INCOMES_GENERAL,
        //ARTROLE_TAX_INCOMES_ADVANCE,
        //ARTROLE_TAX_INCOMES_WITHHOLD,
        //ARTROLE_INS_INCOMES_HEALTH,
        //ARTROLE_INS_INCOMES_SOCIAL,
        //ARTROLE_TAX_ADVANCE_BASE,
        //ARTROLE_TAX_ADVANCE_HEALTH,
        //ARTROLE_TAX_ADVANCE_SOCIAL,
        //ARTROLE_TAX_ADVANCE_PART,
        //ARTROLE_TAX_SOLIDARY_BASE,
        //ARTROLE_TAX_ADVANCE,
        //ARTROLE_TAX_SOLIDARY,
        //ARTROLE_TAX_ADVANCE_FINAL,
        //ARTROLE_TAX_WITHHOLD_BASE,
        //ARTROLE_TAX_WITHHOLD_HEALTH,
        //ARTROLE_TAX_WITHHOLD_SOCIAL,
        //ARTROLE_TAX_WITHHOLD_PART,
        //ARTROLE_TAX_WITHHOLD_FINAL,
        //ARTROLE_TAX_CLAIM_PAYER,
        //ARTROLE_TAX_CLAIM_DISABILITY,
        //ARTROLE_TAX_CLAIM_STUDYING,
        //ARTROLE_TAX_CLAIM_CHILD,
        //ARTROLE_TAX_RELIEF_PAYER,
        //ARTROLE_TAX_RELIEF_CHILD,
        //ARTROLE_TAX_BONUS_CHILD,
        //ARTROLE_INS_HEALTH_BASE,
        //ARTROLE_INS_HEALTH_FINAL,
        //ARTROLE_INS_SOCIAL_BASE,
        //ARTROLE_INS_SOCIAL_FINAL,
        //ARTROLE_INCOME_GROSS,
        //ARTROLE_INCOME_NETTO
    }
    public static class PayrollCzRoleExtensions
    {
        public static string GetSymbol(this PayrollCzRole article)
        {
            return article.ToString();
        }
    }

    public class ArticleRoleFactory
    {
        public static PayrollRole CreateEnum(UInt16 symbolNumb)
        {
            return symbolNumb.ToEnum<PayrollRole>(GetDefaultCode());
        }
        public static PayrollRole CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<PayrollRole>(GetDefaultCode());
        }
        public static UInt16 CreateCode(UInt16 symbolNumb)
        {
            return (UInt16)symbolNumb.ToEnum<PayrollRole>(GetDefaultCode());
        }
        public static UInt16 CreateCode(string symbolName)
        {
            return (UInt16)symbolName.ToEnum<PayrollRole>(GetDefaultCode());
        }
        private static PayrollRole GetDefaultCode()
        {
            return PayrollRole.ARTROLE_UNKNOWN;
        }
    }
}
