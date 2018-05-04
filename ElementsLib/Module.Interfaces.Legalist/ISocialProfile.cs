using System;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using TAmount = Decimal;

    using ElementsLib.Legalist.Constants;
    using Items;
    public interface ISocialProfile
    {
        ISocialGuides Guides();
        TAmount IncludeGeneralIncomes(Period evalPeriod, WorkSocialTerms summarize,
            TAmount includeIncome, TAmount excludeIncome);
        TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkSocialTerms summarize,
            TAmount includeIncome, TAmount excludeIncome);
    }
}