using ElementsLib.Legalist.Config;
using ElementsLib.Module.Interfaces.Legalist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist
{
    public class SimpleLegalistService : LegalistService
    {
        public SimpleLegalistService() : base()
        {
            ModuleAssembly = typeof(LegalistService).Assembly;
        }

        public void InitializeService()
        {
            IBundleVersionFactory versionFactory = new BundleVersionFactory();

            Initialize(versionFactory);
        }
    }
}
