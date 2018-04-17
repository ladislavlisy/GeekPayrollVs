using ClazzGeneratorConsoleApp.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    public class ClazzArticlesBook
    {
        public IList<ArticleDefinition> Book { get; protected set; }

        public ClazzArticlesBook()
        {
            Book = new List<ArticleDefinition>();
        }

        public void InitBook()
        {
            Book = new List<ArticleDefinition>()
            {
                new UnknownDefinition(),
                new ContractTermDefinition(),
                new PositionTermDefinition(),
                new PositionScheduleDefinition(),
                new PositionTimesheetDefinition(),
                new PositionWorkingDefinition(),
                new PositionAbsenceDefinition(),
                new ContractTimesheetDefinition(),
                new ContractWorkingDefinition(),
                new ContractAbsenceDefinition(),
#if ALL_ARTICLES_DEF
                new PositionMonthlyAmountDefinition(),
                new TaxDeclarationDefinition(),
                new InsHealthDeclarationDefinition(),
                new InsSocialDeclarationDefinition(),
                new TaxIncomesGeneralDefinition(),
                new TaxIncomesAdvanceDefinition(),
                new TaxIncomesWithholdDefinition(),
                new InsIncomesHealthDefinition(),
                new InsIncomesSocialDefinition(),
                new TaxAdvanceBaseDefinition(),
                new TaxAdvanceHealthDefinition(),
                new TaxAdvanceSocialDefinition(),
                new TaxAdvancePartDefinition(),
                new TaxSolidaryBaseDefinition(),
                new TaxAdvanceDefinition(),
                new TaxSolidaryDefinition(),
                new TaxAdvanceFinalDefinition(),
                new TaxWithholdBaseDefinition(),
                new TaxWithholdHealthDefinition(),
                new TaxWithholdSocialDefinition(),
                new TaxWithholdPartDefinition(),
                new TaxWithholdFinalDefinition(),
                new TaxClaimPayerDefinition(),
                new TaxClaimDisabilityDefinition(),
                new TaxClaimStudyingDefinition(),
                new TaxClaimChildDefinition(),
                new TaxReliefPayerDefinition(),
                new TaxReliefChildDefinition(),
                new TaxBonusChildDefinition(),
                new InsHealthBaseDefinition(),
                new InsHealthFinalDefinition(),
                new InsSocialBaseDefinition(),
                new InsSocialFinalDefinition(),
                new IncomeGrossDefinition(),
                new IncomeNettoDefinition(),
#endif
            };
        }
    }
}
