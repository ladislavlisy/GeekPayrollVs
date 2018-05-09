using System;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using TAmount = Decimal;

    using ElementsLib.Legalist.Constants;
    using Items;

    public interface ITaxingProfile
    {
        ITaxingGuides Guides();
        TAmount TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize, 
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount TaxableLolevelIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount TaxableAgrWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount TaxablePartnerIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount TaxableIncomesAdvanceTaxingMode(Period evalPeriod, 
            TAmount generalIncome, TAmount excludeIncome, 
            TAmount lolevelIncome, TAmount agrtaskIncome, TAmount partnerIncome);
        TAmount TaxableIncomesWithholdLolevelMode(Period evalPeriod, 
            TAmount generalIncome, TAmount excludeIncome, 
            TAmount lolevelIncome, TAmount agrtaskIncome, TAmount partnerIncome);
        TAmount TaxableIncomesWithholdAgrTaskMode(Period evalPeriod, 
            TAmount generalIncome, TAmount excludeIncome, 
            TAmount lolevelIncome, TAmount agrtaskIncome, TAmount partnerIncome);
        TAmount TaxableIncomesWithholdPartnerMode(Period evalPeriod, 
            TAmount generalIncome, TAmount excludeIncome, 
            TAmount lolevelIncome, TAmount agrtaskIncome, TAmount partnerIncome);
        TAmount TaxableBaseAdvanceTaxingMode(Period evalPeriod, TAmount generalIncome);
        TAmount TaxableBaseWithholdTaxingMode(Period evalPeriod, TAmount generalIncome);
    }
}