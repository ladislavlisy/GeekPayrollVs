using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Versions.Taxing
{
    using TAmount = Decimal;

    using Constants;
    using Module.Interfaces.Legalist;
    using Module.Items;
    public class TaxingGuidingProfile : ITaxingProfile
    {
        protected Period InternalPeriod { get; set; }
        protected ITaxingGuides InternalGuides { get; set; }

        public TaxingGuidingProfile(Period period, ITaxingGuides guides)
        {
            this.InternalPeriod = period;

            this.InternalGuides = guides;
        }

        public ITaxingGuides Guides()
        {
            return InternalGuides;
        }

        public TAmount TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome)
        {
            TAmount totalIncome = decimal.Zero;
            if (statement == TaxStatement.TAXABLE)
            {
                if (declaracy == TaxDeclaracy.SIGNED)
                {
                    totalIncome = decimal.Add(totalIncome, taxableIncome);
                    totalIncome = decimal.Add(totalIncome, partnerIncome);
                }
            }
            return totalIncome;
        }

        public TAmount TaxableLolevelIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome)
        {
            TAmount totalIncome = decimal.Zero;
            if (statement == TaxStatement.TAXABLE)
            {
                if (declaracy == TaxDeclaracy.NONSIGNED)
                {
                    switch (summarize)
                    {
                        case WorkTaxingTerms.TAXING_TERM_EMPLOYMENT_POLICY:
                            totalIncome = decimal.Add(totalIncome, taxableIncome);
                            break;
                        case WorkTaxingTerms.TAXING_TERM_FOR_TASK_AGREEMENT:
                            break;
                        case WorkTaxingTerms.TAXING_TERM_STATUTORY_PARTNER:
                            break;
                    }
                }
            }
            return totalIncome;
        }

        public TAmount TaxableAgrWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome)
        {
            TAmount totalIncome = decimal.Zero;
            if (statement == TaxStatement.TAXABLE)
            {
                if (declaracy == TaxDeclaracy.NONSIGNED)
                {
                    switch (summarize)
                    {
                        case WorkTaxingTerms.TAXING_TERM_EMPLOYMENT_POLICY:
                            break;
                        case WorkTaxingTerms.TAXING_TERM_FOR_TASK_AGREEMENT:
                            totalIncome = decimal.Add(totalIncome, taxableIncome);
                            break;
                        case WorkTaxingTerms.TAXING_TERM_STATUTORY_PARTNER:
                            break;
                    }
                }
            }
            return totalIncome;
        }

        public TAmount TaxablePartnerIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome)
        {
            TAmount totalIncome = decimal.Zero;
            if (statement == TaxStatement.TAXABLE)
            {
                if (declaracy == TaxDeclaracy.NONSIGNED)
                {
                    switch (summarize)
                    {
                        case WorkTaxingTerms.TAXING_TERM_EMPLOYMENT_POLICY:
                        case WorkTaxingTerms.TAXING_TERM_FOR_TASK_AGREEMENT:
                            totalIncome = decimal.Add(totalIncome, partnerIncome);
                            break;
                        case WorkTaxingTerms.TAXING_TERM_STATUTORY_PARTNER:
                            totalIncome = decimal.Add(totalIncome, taxableIncome);
                            totalIncome = decimal.Add(totalIncome, partnerIncome);
                            break;
                    }
                }
            }
            return totalIncome;
        }

        public TAmount ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmount taxableIncome, TAmount partnerIncome, TAmount excludeIncome)
        {
            TAmount totalIncome = decimal.Zero;
            if (statement == TaxStatement.NONTAXABLE)
            {
                totalIncome = decimal.Add(totalIncome, taxableIncome);
                totalIncome = decimal.Add(totalIncome, partnerIncome);
                totalIncome = decimal.Add(totalIncome, excludeIncome);
            }
            else if (statement == TaxStatement.TAXABLE)
            {
                totalIncome = decimal.Add(totalIncome, excludeIncome);
            }
            return totalIncome;
        }
    }
}
