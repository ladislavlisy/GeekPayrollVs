using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Items
{
    using TAmountDec = Decimal;
    public class TaxableIncomeSum
    {
        protected TAmountDec InternalIncomeGeneral { get; set; }
        protected TAmountDec InternalIncomeExclude { get; set; }
        protected TAmountDec InternalIncomeLolevel { get; set; }
        protected TAmountDec InternalIncomeAgrTask { get; set; }
        protected TAmountDec InternalIncomePartner { get; set; }

        public TaxableIncomeSum()
        {
            this.InternalIncomeGeneral = TAmountDec.Zero;
            this.InternalIncomeExclude = TAmountDec.Zero;
            this.InternalIncomeLolevel = TAmountDec.Zero;
            this.InternalIncomeAgrTask = TAmountDec.Zero;
            this.InternalIncomePartner = TAmountDec.Zero;
        }
        public TaxableIncomeSum(TAmountDec general, TAmountDec exclude, TAmountDec lolevel, TAmountDec agrtask, TAmountDec partner)
        {
            this.InternalIncomeGeneral = general;
            this.InternalIncomeExclude = exclude;
            this.InternalIncomeLolevel = lolevel;
            this.InternalIncomeAgrTask = agrtask;
            this.InternalIncomePartner = partner;
        }
        public TAmountDec IncomeGeneral()
        {
            return InternalIncomeGeneral;
        }
        public TAmountDec IncomeExclude()
        {
            return InternalIncomeExclude;
        }
        public TAmountDec IncomeLolevel()
        {
            return InternalIncomeLolevel;
        }
        public TAmountDec IncomeAgrTask()
        {
            return InternalIncomeAgrTask;
        }
        public TAmountDec IncomePartner()
        {
            return InternalIncomePartner;
        }
        public TaxableIncomeSum Aggregate(TAmountDec general, TAmountDec exclude, TAmountDec lolevel, TAmountDec agrtask, TAmountDec partner)
        {
            return new TaxableIncomeSum(InternalIncomeGeneral + general, InternalIncomeExclude + exclude, 
                InternalIncomeLolevel + lolevel, InternalIncomeAgrTask + agrtask, InternalIncomePartner + partner);
        }
    }
}
