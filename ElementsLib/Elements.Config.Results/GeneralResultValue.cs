using System;

namespace ElementsLib.Elements.Config.Results
{
    using ResultCode = UInt16;

    using Module.Interfaces.Elements;
    public abstract class GeneralResultValue : IArticleResultValues
    {
        public GeneralResultValue(ResultCode code)
        {
            Code = code;
        }
        protected ResultCode Code { get; set; }
        public abstract string Description();

        public virtual bool IsWorkWeekValue()
        {
            return Code == (ResultCode)ArticleResultCode.RESULT_VALUE_WORK_WEEK_HOURS;
        }
        public virtual bool IsMonthFromStopValue()
        {
            return Code == (ResultCode)ArticleResultCode.RESULT_VALUE_MONTH_FROM_STOP;
        }
        public virtual bool IsFullMonthValue()
        {
            return Code == (ResultCode)ArticleResultCode.RESULT_VALUE_FULL_MONTH_HOURS;
        }
        public virtual bool IsTermMonthValue()
        {
            return Code == (ResultCode)ArticleResultCode.RESULT_VALUE_TERM_MONTH_HOURS;
        }
    }
}