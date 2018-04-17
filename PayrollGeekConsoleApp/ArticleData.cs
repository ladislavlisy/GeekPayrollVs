using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElementsLib.Module.Interfaces.Elements;

namespace PayrollGeekConsoleApp
{
    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigCode = UInt16;
    using HolderSeed = UInt16;
    using BodyTags = ISourceValues;

    public class ArticleData
    {
        public HolderHead Head { get; set; }
        public HolderPart Part { get; set; }
        public ConfigCode Code { get; set; }
        public HolderSeed Seed { get; set; }
        public BodyTags Tags { get; set; }

    }

}
