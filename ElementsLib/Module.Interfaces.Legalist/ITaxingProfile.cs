using System;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using TAmount = Decimal;

    using ElementsLib.Legalist.Constants;
    using Items;

    public interface ITaxingProfile
    {
        ITaxingGuides Guides();
        TAmount TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize);
        TAmount TaxableAggWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize);
        TAmount TaxableStatutsIncomes(Period evalPeriod, WorkTaxingTerms summarize);
        TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize);
    }
}