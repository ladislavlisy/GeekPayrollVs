﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using ConfigCode = UInt16;
    using ResultCode = UInt16;

    using TDay = Byte;
    using TSeconds = Int32;

    using Module.Interfaces.Elements;
    using Module.Libs;
    using MaybeMonad;
    using Module.Codes;

    public class ArticleGeneralResult : IArticleResult
    {
        public ArticleGeneralResult(ConfigCode code)
        {
            InternalCode = code;
            ResultValues = new ResultValuesStore();
        }
        public IArticleResult AddWorkWeeksFullScheduleValue(TSeconds[] hoursWeek)
        {
            IArticleResultValues value = new WorkWeekResultValue((ResultCode)ArticleResultCode.RESULT_VALUE_FULL_WEEKS_HOURS, hoursWeek);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkWeeksRealScheduleValue(TSeconds[] hoursWeek)
        {
            IArticleResultValues value = new WorkWeekResultValue((ResultCode)ArticleResultCode.RESULT_VALUE_REAL_WEEKS_HOURS, hoursWeek);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        
        public IArticleResult AddMonthFromStop(TDay dayFrom, TDay dayStop)
        {
            IArticleResultValues value = new MonthFromStopResultValue(dayFrom, dayStop);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkMonthFullScheduleValue(TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new WorkMonthResultValue((ResultCode)ArticleResultCode.RESULT_VALUE_FULL_MONTH_HOURS, hoursMonth);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkMonthRealScheduleValue(TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new WorkMonthResultValue((ResultCode)ArticleResultCode.RESULT_VALUE_REAL_MONTH_HOURS, hoursMonth);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkMonthTermScheduleValue(TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new WorkMonthResultValue((ResultCode)ArticleResultCode.RESULT_VALUE_TERM_MONTH_HOURS, hoursMonth);

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
            string articleCode = ArticleCodeAdapter.GetSymbol(InternalCode);

            string articleDesc = string.Join("\r\n", ResultValues.Select((v) => (v.Description())));

            return string.Format("{0}\r\n{1}", articleCode, articleDesc);
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
