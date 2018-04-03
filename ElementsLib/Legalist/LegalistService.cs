using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    using System.Reflection;

    public class LegalistService : ILegalistService
    {

    }
}
