using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using TDay = Byte;
    using TSeconds = Int32;
    public interface IArticleResult : ICloneable
    {
        ConfigCode Code();
        IArticleResult AddWorkWeeksFullScheduleValue(TSeconds[] hoursWeek);
        IArticleResult AddWorkWeeksRealScheduleValue(TSeconds[] hoursWeek);
        IArticleResult AddMonthFromStop(TDay dayFrom, TDay dayStop);
        IArticleResult AddWorkMonthFullScheduleValue(TSeconds[] hoursMonth);
        IArticleResult AddWorkMonthRealScheduleValue(TSeconds[] hoursMonth);
        IArticleResult AddWorkMonthTermScheduleValue(TSeconds[] hoursMonth);
    }
}
