using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist
{
    using BundleFocus = UInt16;

    using Module.Interfaces;
    using Module.Interfaces.Legalist;
    using Module.Items;
    public class LegalistService : ILegalistService
    {
        public LegalistService()
        {
            this.Profiles = new Dictionary<BundleFocus, IBundleProfile>();
        }

        public IPeriodProfile GetPeriodProfile(Period period)
        {
            var profile = Profiles.FirstOrDefault((p) => IsValidForPeriod(period, p.Key));

            if (profile.Value == null)
            {
                return null;
            }
            return new PeriodProfile(period, profile.Value);
        }

        private bool IsValidForPeriod(Period period, BundleFocus profileKey)
        {
            return (period.YearUInt() == profileKey);
        }

        protected IDictionary<BundleFocus, IBundleProfile> Profiles;

    }
}
