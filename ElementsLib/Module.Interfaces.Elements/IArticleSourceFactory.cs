using System;
using System.Collections.Generic;
using System.Reflection;

namespace ElementsLib.Module.Interfaces.Elements
{
    using BodyCode = UInt16;
    using BodyItem = IArticleSource;
    using BodyPair = KeyValuePair<UInt16, IArticleSource>;

    public interface IArticleSourceFactory
    {
        IEnumerable<BodyPair> CreateSourceList(Assembly configAssembly);
        BodyItem CreateSourceItem(Assembly configAssembly, BodyCode symbolCode, BodyCode backupCode);
    }
}
