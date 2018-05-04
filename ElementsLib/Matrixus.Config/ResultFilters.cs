using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Config
{
    using ResultItem = Module.Interfaces.Elements.IArticleResultValues;
    public static class ResultFilters
    {
        public static bool PaymentMoneyFunc(ResultItem result)
        {
            return (result.IsPaymentMoneyValue());
        }
        public static bool MonthAttendanceFunc(ResultItem result)
        {
            return (result.IsMonthAttendanceValue());
        }
    }
}
