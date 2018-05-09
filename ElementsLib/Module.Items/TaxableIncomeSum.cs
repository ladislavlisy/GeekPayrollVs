using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Items
{
    using TAmount = Decimal;
    public class TaxableIncomeSum
    {
        protected TAmount InternalIncomeGeneral { get; set; }
        protected TAmount InternalIncomeExclude { get; set; }
        protected TAmount InternalIncomeLolevel { get; set; }
        protected TAmount InternalIncomeAgrTask { get; set; }
        protected TAmount InternalIncomePartner { get; set; }

        public TaxableIncomeSum()
        {
            this.InternalIncomeGeneral = TAmount.Zero;
            this.InternalIncomeExclude = TAmount.Zero;
            this.InternalIncomeLolevel = TAmount.Zero;
            this.InternalIncomeAgrTask = TAmount.Zero;
            this.InternalIncomePartner = TAmount.Zero;
        }
        public TaxableIncomeSum(TAmount general, TAmount exclude, TAmount lolevel, TAmount agrtask, TAmount partner)
        {
            this.InternalIncomeGeneral = general;
            this.InternalIncomeExclude = exclude;
            this.InternalIncomeLolevel = lolevel;
            this.InternalIncomeAgrTask = agrtask;
            this.InternalIncomePartner = partner;
        }
        public TAmount IncomeGeneral()
        {
            return InternalIncomeGeneral;
        }
        public TAmount IncomeExclude()
        {
            return InternalIncomeExclude;
        }
        public TAmount IncomeLolevel()
        {
            return InternalIncomeLolevel;
        }
        public TAmount IncomeAgrTask()
        {
            return InternalIncomeAgrTask;
        }
        public TAmount IncomePartner()
        {
            return InternalIncomePartner;
        }
        public TaxableIncomeSum Aggregate(TAmount general, TAmount exclude, TAmount lolevel, TAmount agrtask, TAmount partner)
        {
            return new TaxableIncomeSum(InternalIncomeGeneral + general, InternalIncomeExclude + exclude, 
                InternalIncomeLolevel + lolevel, InternalIncomeAgrTask + agrtask, InternalIncomePartner + partner);
        }
    }
}
