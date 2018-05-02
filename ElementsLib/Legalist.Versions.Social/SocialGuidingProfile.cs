using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Versions.Social
{
    using TAmount = Decimal;

    using Constants;
    using Module.Interfaces.Legalist;
    using Module.Items;
    public class SocialGuidingProfile : ISocialProfile
    {
        protected Period InternalPeriod { get; set; }
        protected ISocialGuides InternalGuides { get; set; }

        public SocialGuidingProfile(Period period, ISocialGuides guides)
        {
            this.InternalPeriod = period;

            this.InternalGuides = guides;
        }

        public ISocialGuides Guides()
        {
            return InternalGuides;
        }

        public TAmount IncludeGeneralIncomes(Period evalPeriod, WorkSocialTerms summarize)
        {
            throw new NotImplementedException();
        }

        public TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkSocialTerms summarize)
        {
            throw new NotImplementedException();
        }
    }
}
