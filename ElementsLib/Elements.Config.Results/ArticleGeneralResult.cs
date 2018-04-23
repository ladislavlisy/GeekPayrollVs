using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using ConfigCode = UInt16;

    using TDay = Byte;
    using TSeconds = Int32;

    using Module.Interfaces.Elements;
    using Module.Libs;
    using MaybeMonad;

    public class ArticleGeneralResult : IArticleResult
    {
        public ArticleGeneralResult(ConfigCode code)
        {
            InternalCode = code;
            ResultValues = new ResultValuesStore();
        }
        public IArticleResult AddWorkWeekValue(int[] hoursWeek)
        {
            IArticleResultValues value = new WorkWeekResultValue(hoursWeek);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        
        public IArticleResult AddMonthFromStop(TDay dayFrom, TDay dayStop)
        {
            IArticleResultValues value = new MonthFromStopResultValue(dayFrom, dayStop);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        
        protected ConfigCode InternalCode { get; set; }
        protected ResultValuesStore ResultValues { get; set; }

        public ConfigCode Code()
        {
            return InternalCode;
        }
        public object Clone()
        {
            ArticleGeneralResult cloneResult = (ArticleGeneralResult)this.MemberwiseClone();
            cloneResult.InternalCode = InternalCode;
            cloneResult.ResultValues = CloneUtils<ResultValuesStore>.CloneOrNull(ResultValues);

            return cloneResult;
        }

        public override string ToString()
        {
            return string.Join(",", ResultValues.Select((v) => (v.Description())));
        }

        public Maybe<T> ReturnValue<T>(Func<IArticleResultValues, bool> filterFunc) where T : class, IArticleResultValues
        {
            IArticleResultValues generalvalue = ResultValues.SingleOrDefault(filterFunc);
            T value = generalvalue as T;
            if (value == null)
            {
                return Maybe<T>.Nothing;
            }
            return Maybe.From<T>(value);
        }
    }
}
