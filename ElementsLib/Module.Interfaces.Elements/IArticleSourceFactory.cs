using System;
using System.Collections.Generic;
using System.Reflection;

namespace ElementsLib.Module.Interfaces.Elements
{
    using SourceCode = UInt16;
    using SourceItem = IArticleSource;
    using SourcePair = KeyValuePair<UInt16, IArticleSource>;

    public interface IArticleSourceFactory
    {
        IEnumerable<SourcePair> CreateSourceList(Assembly configAssembly);
        SourceItem CreateSourceItem(Assembly configAssembly, SourceCode symbolCode, SourceCode backupCode);
    }
}
