using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using EnumCode = UInt16;
    public enum ArticleResultCode : EnumCode
    {
        RESULT_VALUE_WORK_WEEK_HOURS = 0,
        RESULT_VALUE_MONTH_FROM_STOP,
        RESULT_VALUE_FULL_MONTH_HOURS,
        RESULT_VALUE_TERM_MONTH_HOURS
    }
    public static class ArticleCzCodeExtensions
    {
        public static string GetSymbol(this ArticleResultCode article)
        {
            return article.ToString();
        }
    }
}
