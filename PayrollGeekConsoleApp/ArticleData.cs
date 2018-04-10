using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElementsLib.Module.Interfaces.Elements;

namespace PayrollGeekConsoleApp
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;
    using BodyTags = ISourceValues;

    public class ArticleData
    {
        public HeadCode Head { get; set; }
        public PartCode Part { get; set; }
        public BodyCode Code { get; set; }
        public BodySeed Seed { get; set; }
        public BodyTags Tags { get; set; }

    }

}
