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
        #region CONFIG_GENERATOR
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
                new ContractAttendItemDefinition(),
                new PositionMonthlyAmountDefinition(),
                new TaxDeclarationDefinition(),
                new InsDeclarationHealthDefinition(),
                new InsDeclarationSocialDefinition(),
                new TaxIncomesGeneralDefinition(),
                new TaxIncomesHealthDefinition(),
                new TaxIncomesSocialDefinition(),
                new InsIncomesHealthDefinition(),
                new InsIncomesSocialDefinition(),
                new TaxIncomesAdvanceDefinition(),
                new TaxIncomesWithholdGeneralDefinition(),
                new TaxBaseAdvanceDefinition(),
                new TaxBaseAdvanceHealthDefinition(),
                new TaxBaseAdvanceSocialDefinition(),
                new TaxBaseAdvancePartialDefinition(),
                new TaxBaseAdvanceOrdinaryDefinition(),
                new TaxBaseAdvanceSolidaryDefinition(),
                new TaxBaseWithholdDefinition(),
                new TaxAdvanceOrdinaryDefinition(),
                new TaxAdvanceSolidaryDefinition(),
                new InsBaseHealthCompoundDefinition(),
                new InsBaseHealthEmployerDefinition(),
                new InsBaseHealthEmployeeDefinition(),
                new InsBaseSocialCompoundDefinition(),
                new InsHealthFinalDefinition(),
                new InsSocialFinalDefinition(),
#if ALL_ARTICLES_DEF
                new TaxAdvanceFinalDefinition(),
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
                new IncomeGrossDefinition(),
                new IncomeNettoDefinition(),
#endif
            };
        }
        #endregion
    }
}
