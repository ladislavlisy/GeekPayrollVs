using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElementsLib.Module.Interfaces.Elements;

namespace PayrollGeekConsoleApp
{
    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using ConfigCode = UInt16;
    using TargetSeed = UInt16;
    using BodyTags = ISourceValues;

    public class ArticleData
    {
        public TargetHead Head { get; set; }
        public TargetPart Part { get; set; }
        public ConfigCode Code { get; set; }
        public TargetSeed Seed { get; set; }
        public BodyTags Tags { get; set; }

    }

}
