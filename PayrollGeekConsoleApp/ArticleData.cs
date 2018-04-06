using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElementsLib.Module.Interfaces.Elements;

namespace PayrollGeekConsoleApp
{
    using ArticleCode = UInt16;
    using ServiceCode = UInt16;
    using EpisodeCode = UInt16;
    using ArticleVals = ISourceValues;

    public class ArticleData
    {
        public ServiceCode Service { get; set; }
        public EpisodeCode Episode { get; set; }
        public EpisodeCode Placing { get; set; }
        public EpisodeCode Sorting { get; set; }
        public ArticleCode Article { get; set; }
        public ArticleVals Records { get; set; }

    }

}
