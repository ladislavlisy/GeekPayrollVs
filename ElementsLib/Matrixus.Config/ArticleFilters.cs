using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Config
{
    using ResultItem = Module.Interfaces.Elements.IArticleResult;
    public static class ArticleFilters
    {
        public static bool SelectAllFunc(ResultItem result)
        {
            return true;
        }
        public static bool TaxIncomeFunc(ResultItem result)
        {
            return result.IsTaxingIncome();
        }
    }
}
