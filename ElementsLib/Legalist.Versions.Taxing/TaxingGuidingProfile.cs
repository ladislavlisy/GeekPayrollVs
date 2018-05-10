using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Legalist.Versions.Taxing
{
    using TAmountDec = Decimal;

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

        public TAmountDec TaxableGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
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

        public TAmountDec TaxableLolevelIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
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

        public TAmountDec TaxableAgrWorkIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
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

        public TAmountDec TaxablePartnerIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
            if (statement == TaxStatement.TAXABLE)
            {
                if (InternalGuides.TaxPartnerIncomeWithhold() == TaxingPartnerIncome.TAXING_WITHHOLD)
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
                else if (InternalGuides.TaxPartnerIncomeWithhold() == TaxingPartnerIncome.NONSIGNED_WITHHOLD)
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
            }
            return totalIncome;
        }

        public TAmountDec ExcludeGeneralIncomes(Period evalPeriod, WorkTaxingTerms summarize,
            Byte statement, Byte declaracy, Byte residency,
            TAmountDec taxableIncome, TAmountDec partnerIncome, TAmountDec excludeIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
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

        public TAmountDec TaxableIncomesAdvanceTaxingMode(Period evalPeriod,
            TAmountDec generalIncome, TAmountDec excludeIncome,
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
            totalIncome = decimal.Add(totalIncome, generalIncome);
            if (InternalGuides.TaxLoLevelIncomeWithhold()==false)
            {
                totalIncome = decimal.Add(totalIncome, lolevelIncome);
            }
            else if (InternalGuides.MaxLoLevelIncomeWithhold() > lolevelIncome)
            {
                totalIncome = decimal.Add(totalIncome, lolevelIncome);
            }
            if (InternalGuides.TaxTaskAgrIncomeWithhold()==false)
            {
                totalIncome = decimal.Add(totalIncome, agrtaskIncome);
            }
            else if (InternalGuides.MaxTaskAgrIncomeWithhold() > agrtaskIncome)
            {
                totalIncome = decimal.Add(totalIncome, agrtaskIncome);
            }
            return totalIncome;
        }
        public TAmountDec TaxableIncomesWithholdLolevelMode(Period evalPeriod,
            TAmountDec generalIncome, TAmountDec excludeIncome,
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
            if (InternalGuides.TaxLoLevelIncomeWithhold())
            {
                if (lolevelIncome > 0 && InternalGuides.MaxLoLevelIncomeWithhold() <= lolevelIncome)
                {
                    totalIncome = decimal.Add(totalIncome, lolevelIncome);
                }
            }
            return totalIncome;
        }

        public TAmountDec TaxableIncomesWithholdTaskAgrMode(Period evalPeriod,
            TAmountDec generalIncome, TAmountDec excludeIncome,
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
            if (InternalGuides.TaxTaskAgrIncomeWithhold())
            {
                if (agrtaskIncome > 0 && InternalGuides.MaxTaskAgrIncomeWithhold() <= agrtaskIncome)
                {
                    totalIncome = decimal.Add(totalIncome, agrtaskIncome);
                }
            }
            return totalIncome;
        }

        public TAmountDec TaxableIncomesWithholdPartnerMode(Period evalPeriod,
            TAmountDec generalIncome, TAmountDec excludeIncome,
            TAmountDec lolevelIncome, TAmountDec agrtaskIncome, TAmountDec partnerIncome)
        {
            TAmountDec totalIncome = decimal.Zero;
            if (InternalGuides.TaxPartnerIncomeWithhold()!=TaxingPartnerIncome.TAXING_ADVANCE)
            {
                totalIncome = decimal.Add(totalIncome, partnerIncome);
            }
            return totalIncome;
        }
        public TAmountDec TaxableBaseAdvanceTaxingMode(Period evalPeriod, TAmountDec generalIncome)
        {
            return generalIncome;
        }

        public TAmountDec TaxableBaseWithholdTaxingMode(Period evalPeriod, TAmountDec generalIncome)
        {
            return generalIncome;
        }

    }
}
