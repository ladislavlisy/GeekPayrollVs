using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ElementsLib.Legalist
{
    using VersionCode = UInt16;

    using VersionItem = Module.Interfaces.Legalist.IBundleProfile;
    using VersionPair = KeyValuePair<UInt16, Module.Interfaces.Legalist.IBundleProfile>;

    using Module.Interfaces;
    using Module.Interfaces.Legalist;
    using Module.Items;
    using Exceptions;
    using Bundles;
    using Config;

    public class LegalistService : ILegalistService
    {
        protected Assembly ModuleAssembly { get; set; }

        public LegalistService()
        {
            ModuleAssembly = null;

            VersionFactory = null;

            VersionProfile = null;
        }

        public void Initialize(IBundleVersionFactory versionFactory)
        {
            VersionFactory = versionFactory;

            VersionProfile = new BundleVersionCollection();

            VersionProfile.InitBundleProfiles(ModuleAssembly, versionFactory);
        }

        public IBundleVersionCollection Profile()
        {
            return VersionProfile;
        }

        public IPeriodProfile GetPeriodProfile(Period period)
        {
            return VersionProfile.GetPeriodProfile(period);
        }

        protected IBundleVersionFactory VersionFactory { get; set; }

        protected IBundleVersionCollection VersionProfile { get; set; }
    }
}
