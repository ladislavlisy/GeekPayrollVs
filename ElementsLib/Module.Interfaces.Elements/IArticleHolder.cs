using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigCode = UInt16;
    using HolderSeed = UInt16;
    using HolderSort = UInt16;

    public interface IArticleHolder : IComparable<IArticleHolder>, IEquatable<IArticleHolder>
    {
        HolderHead Head();
        HolderPart Part();
        ConfigCode Code();
        HolderSeed Seed();
        bool IsEqualToHeadHolderPart(IArticleHolder other);
        bool IsEqualToHeadHolderPart(HolderHead otherHead, HolderPart otherPart, ConfigCode otherCode);
        string ToSymbolString<TENUM>() where TENUM : struct, IComparable;
    }
}
