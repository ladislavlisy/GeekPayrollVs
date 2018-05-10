using System;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using TAmountDec = Decimal;

    using ElementsLib.Legalist.Constants;
    using Items;

    public interface ITaxingProfile
    {
        ITaxingGuides Guides();
        TAmountDec TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize, 
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome);
        TAmountDec TaxableLolevelIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome);
        TAmountDec TaxableAgrWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome);
        TAmountDec TaxablePartnerIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome);
        TAmountDec ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome);
        TAmountDec TaxableIncomesAdvanceTaxingMode(Period evalPeriod, 
            TAmountDec generalIncome, TAmountDec excludeIncome, 
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome);
        TAmountDec TaxableIncomesWithholdLolevelMode(Period evalPeriod, 
            TAmountDec generalIncome, TAmountDec excludeIncome, 
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome);
        TAmountDec TaxableIncomesWithholdTaskAgrMode(Period evalPeriod, 
            TAmountDec generalIncome, TAmountDec excludeIncome, 
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome);
        TAmountDec TaxableIncomesWithholdPartnerMode(Period evalPeriod, 
            TAmountDec generalIncome, TAmountDec excludeIncome, 
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome);
        TAmountDec TaxableBaseAdvanceTaxingMode(Period evalPeriod, TAmountDec generalIncome);
        TAmountDec TaxableBaseWithholdTaxingMode(Period evalPeriod, TAmountDec generalIncome);
    }
}