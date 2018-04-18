using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using ConfigCode = UInt16;
    using TargetSeed = UInt16;
    using TargetSort = UInt16;

    public interface IArticleTarget : IComparable<IArticleTarget>, IEquatable<IArticleTarget>
    {
        TargetHead Head();
        TargetPart Part();
        ConfigCode Code();
        TargetSeed Seed();
        bool IsEqualToHeadTargetPart(IArticleTarget other);
        bool IsEqualToHeadTargetPart(TargetHead otherHead, TargetPart otherPart, ConfigCode otherCode);
        string ToSymbolString<TENUM>() where TENUM : struct, IComparable;
    }
}
