using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;
    using BodySort = UInt16;

    public interface IArticleTarget : IComparable<IArticleTarget>, IEquatable<IArticleTarget>
    {
        HeadCode Head();
        PartCode Part();
        BodyCode Code();
        BodySeed Seed();
        bool IsEqualToHeadPartCode(HeadCode otherHead, PartCode otherPart, BodyCode otherCode);
    }
}
