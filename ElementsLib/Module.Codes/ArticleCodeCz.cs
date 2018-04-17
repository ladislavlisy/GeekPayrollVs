using System;

namespace ElementsLib.Module.Codes
{
    using EnumCode = UInt16;
    public enum ArticleCodeCz : EnumCode
    {
        TARGET_UNKNOWN = 0,
        TARGET_CONTRACT_TERM,
        TARGET_POSITION_TERM,
        TARGET_POSITION_SCHEDULE,
        TARGET_POSITION_TIMESHEET,
        TARGET_POSITION_WORKING,
        TARGET_POSITION_ABSENCE,
        TARGET_CONTRACT_TIMESHEET,
        TARGET_CONTRACT_WORKING,
        TARGET_CONTRACT_ABSENCE,
        TARGET_POSITION_MONTHLY_AMOUNT = 10000,
        TARGET_TAX_DECLARATION,
        TARGET_INS_HEALTH_DECLARATION,
        TARGET_INS_SOCIAL_DECLARATION,
        TARGET_TAX_INCOMES_GENERAL,
        TARGET_TAX_INCOMES_ADVANCE,
        TARGET_TAX_INCOMES_WITHHOLD,
        TARGET_INS_INCOMES_HEALTH,
        TARGET_INS_INCOMES_SOCIAL,
        TARGET_TAX_ADVANCE_BASE,
        TARGET_TAX_ADVANCE_HEALTH,
        TARGET_TAX_ADVANCE_SOCIAL,
        TARGET_TAX_ADVANCE_PART,
        TARGET_TAX_SOLIDARY_BASE,
        TARGET_TAX_ADVANCE,
        TARGET_TAX_SOLIDARY,
        TARGET_TAX_ADVANCE_FINAL,
        TARGET_TAX_WITHHOLD_BASE,
        TARGET_TAX_WITHHOLD_HEALTH,
        TARGET_TAX_WITHHOLD_SOCIAL,
        TARGET_TAX_WITHHOLD_PART,
        TARGET_TAX_WITHHOLD_FINAL,
        TARGET_TAX_CLAIM_PAYER,
        TARGET_TAX_CLAIM_DISABILITY,
        TARGET_TAX_CLAIM_STUDYING,
        TARGET_TAX_CLAIM_CHILD,
        TARGET_TAX_RELIEF_PAYER,
        TARGET_TAX_RELIEF_CHILD,
        TARGET_TAX_BONUS_CHILD,
        TARGET_INS_HEALTH_BASE,
        TARGET_INS_HEALTH_FINAL,
        TARGET_INS_SOCIAL_BASE,
        TARGET_INS_SOCIAL_FINAL,
        TARGET_INCOME_GROSS,
        TARGET_INCOME_NETTO
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
            return (EnumCode)ArticleCodeCz.TARGET_CONTRACT_TERM;
        }
        public static EnumCode GetPositionCode()
        {
            return (EnumCode)ArticleCodeCz.TARGET_POSITION_TERM;
        }
    }
}
