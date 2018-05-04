using System;

namespace ElementsLib.Module.Interfaces.Legalist
{
    using TAmount = Decimal;

    using ElementsLib.Legalist.Constants;
    using Items;
    public interface IHealthProfile
    {
        IHealthGuides Guides();
        TAmount IncludeGeneralIncomes(Period evalPeriod, WorkHealthTerms summarize,
            TAmount includeIncome, TAmount excludeIncome);
        TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkHealthTerms summarize,
            TAmount includeIncome, TAmount excludeIncome);
    }
}