using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Versions.Taxing
{
    using TAmount = Decimal;

    using Constants;
    using Module.Interfaces.Legalist;
    using Module.Items;
    public class TaxingGuidingProfile : ITaxingProfile
    {
        protected Period InternalPeriod { get; set; }
        protected ITaxingGuides InternalGuides { get; set; }

        public TaxingGuidingProfile(Period period, ITaxingGuides guides)
        {
            this.InternalPeriod = period;

            this.InternalGuides = guides;
        }

        public ITaxingGuides Guides()
        {
            return InternalGuides;
        }

        public TAmount TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize)
        {
            throw new NotImplementedException();
        }

        public TAmount TaxableAggWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize)
        {
            throw new NotImplementedException();
        }

        public TAmount TaxableStatutsIncomes(Period evalPeriod, WorkTaxingTerms summarize)
        {
            throw new NotImplementedException();
        }

        public TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize)
        {
            throw new NotImplementedException();
        }
    }
}
