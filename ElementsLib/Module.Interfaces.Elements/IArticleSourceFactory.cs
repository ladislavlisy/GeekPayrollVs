using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using SourceCode = UInt16;
    using SourceItem = IArticleConfig;
    using SourcePair = KeyValuePair<UInt16, IArticleSource>;

    public interface IArticleSourceFactory
    {
        IEnumerable<SourcePair> CreateSourceList();
    }
}
