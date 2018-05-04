using ElementsLib.Module.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Config
{
    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using TargetCode = UInt16;
    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    public static class TargetFilters
    {
        public static Func<TargetItem, bool> TargetHeadFunc(TargetHead targetHead)
        {
            return (x) => (x.IsEqualByHead(targetHead));
        }
        public static Func<TargetItem, bool> TargetCodePlusHeadFunc(TargetCode targetCode, TargetHead targetHead)
        {
            return (x) => (x.IsEqualByCodePlusHead(targetCode, targetHead));
        }
        public static Func<TargetItem, bool> TargetCodePlusPartFunc(TargetCode targetCode, TargetHead targetHead, TargetPart targetPart)
        {
            return (x) => (x.IsEqualByCodePlusHeadAndPart(targetCode, targetHead, targetPart));
        }
    }
}
