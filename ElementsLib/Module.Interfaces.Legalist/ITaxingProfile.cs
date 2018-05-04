using System;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using TAmount = Decimal;

    using ElementsLib.Legalist.Constants;
    using Items;

    public interface ITaxingProfile
    {
        ITaxingGuides Guides();
        TAmount TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize, Byte statement, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount TaxableAgrWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize, Byte statement, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount TaxablePartnerIncomes(Period evalPeriod, WorkTaxingTerms summarize, Byte statement, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
        TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize, Byte statement, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome);
    }
}