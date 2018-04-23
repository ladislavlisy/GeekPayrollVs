using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using TDay = Byte;
    public interface IArticleResult : ICloneable
    {
        ConfigCode Code();
        IArticleResult AddWorkWeekValue(int[] hoursWeek);
        IArticleResult AddMonthFromStop(TDay dayFrom, TDay dayStop);
    }
}
