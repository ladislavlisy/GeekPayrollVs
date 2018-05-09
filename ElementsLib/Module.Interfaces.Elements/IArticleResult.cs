using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigCode = UInt16;
    using ConfigBase = Module.Interfaces.Matrixus.IArticleBaseFeatures;
    using ConfigGang = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using ConfigBind = UInt16;
    using ResultCode = UInt16;

    using TDay = Byte;
    using TSeconds = Int32;
    using TAmount = Decimal;

    using ElementsLib.Legalist.Constants;
    using MaybeMonad;
    using Matrixus;

    public interface IArticleResult : IArticleBaseFeatures, ICloneable
    {
        ConfigBase Config();
        IArticleResult AddContractFromStop(DateTime? dateFrom, DateTime? dateStop, WorkEmployTerms contractType);
        IArticleResult AddPositionFromStop(DateTime? dateFrom, DateTime? dateStop, WorkPositionType positionType);
        IArticleResult AddMonthFromStop(TDay dayFrom, TDay dayStop);
        IArticleResult AddWorkWeeksFullScheduleValue(TSeconds[] hoursWeek);
        IArticleResult AddWorkWeeksRealScheduleValue(TSeconds[] hoursWeek);
        IArticleResult AddWorkMonthFullScheduleValue(TSeconds[] hoursMonth);
        IArticleResult AddWorkMonthRealScheduleValue(TSeconds[] hoursMonth);
        IArticleResult AddWorkMonthTermScheduleValue(TSeconds[] hoursMonth);
        IArticleResult AddMonthAttendanceScheduleValue(TDay dayFrom, TDay dayStop, TSeconds[] hoursMonth);
        IArticleResult AddMoneyPaymentValue(TAmount paymentAmount);
        IArticleResult AddMoneyTransferValue(TAmount transferAmount);
        IArticleResult AddMoneyTransferIncomeValue(TAmount incomeAmount);
        IArticleResult AddMoneyTransferBasisValue(TAmount basisAmount);
        IArticleResult AddDeclarationTaxingValue(Byte statement, WorkTaxingTerms summarize, Byte declaracy, Byte residency);
        IArticleResult AddDeclarationHealthValue(Byte statement, WorkHealthTerms summarize, TAmount totalBase, Byte foreigner);
        IArticleResult AddDeclarationSocialValue(Byte statement, WorkSocialTerms summarize, TAmount totalBase, Byte foreigner);
        IArticleResult AddIncomeTaxGeneralValue(WorkTaxingTerms summarize, Byte statement, Byte residency, 
            TAmount general, TAmount lolevel, TAmount agrtask, TAmount partner, TAmount exclude);
        IArticleResult AddIncomeInsHealthValue(WorkHealthTerms summarize, TAmount related, TAmount exclude);
        IArticleResult AddIncomeInsSocialValue(WorkSocialTerms summarize, TAmount related, TAmount exclude);

        Maybe<T> ReturnValue<T>(Func<IArticleResultValues, bool> filterFunc) where T : class, IArticleResultValues;
        Maybe<T> ReturnValueForResultCode<T>(ResultCode filterCode) where T : class, IArticleResultValues;
    }
}
