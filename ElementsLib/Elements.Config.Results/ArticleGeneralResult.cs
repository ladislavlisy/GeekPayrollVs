using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using ConfigCode = UInt16;
    using ConfigBase = Module.Interfaces.Matrixus.IArticleBaseFeatures;
    using ConfigProp = Module.Interfaces.Matrixus.IArticleConfigFeatures;
    using ConfigGang = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using ConfigBind = UInt16;
    using ResultCode = UInt16;

    using TDay = Byte;
    using TSeconds = Int32;
    using TAmount = Decimal;

    using Module.Interfaces.Elements;
    using Module.Libs;
    using MaybeMonad;
    using Module.Codes;
    using Legalist.Constants;
    using Module.Interfaces.Matrixus;

    public class ArticleGeneralResult : IArticleResult
    {
        public ArticleGeneralResult(IArticleConfigFeatures config)
        {
            InternalConfig = CloneUtils<IArticleConfigFeatures>.CloneOrNull(config);

            ResultValues = new ResultValuesStore();
        }
        public IArticleResult AddWorkWeeksFullScheduleValue(TSeconds[] hoursWeek)
        {
            IArticleResultValues value = new WeekScheduleValue((ResultCode)ArticleResultCode.RESULT_VALUE_FULL_WEEKS_HOURS, hoursWeek);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkWeeksRealScheduleValue(TSeconds[] hoursWeek)
        {
            IArticleResultValues value = new WeekScheduleValue((ResultCode)ArticleResultCode.RESULT_VALUE_REAL_WEEKS_HOURS, hoursWeek);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        
        public IArticleResult AddContractFromStop(DateTime? dateFrom, DateTime? dateStop, WorkEmployTerms contractType)
        {
            IArticleResultValues value = new ContractFromStopValue(dateFrom, dateStop, contractType);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddPositionFromStop(DateTime? dateFrom, DateTime? dateStop, WorkPositionType positionType)
        {
            IArticleResultValues value = new PositionFromStopValue(dateFrom, dateStop, positionType);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddMonthFromStop(TDay dayFrom, TDay dayStop)
        {
            IArticleResultValues value = new MonthFromStopValue(dayFrom, dayStop);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkMonthFullScheduleValue(TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new MonthScheduleValue((ResultCode)ArticleResultCode.RESULT_VALUE_FULL_MONTH_HOURS, hoursMonth);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkMonthRealScheduleValue(TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new MonthScheduleValue((ResultCode)ArticleResultCode.RESULT_VALUE_REAL_MONTH_HOURS, hoursMonth);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddWorkMonthTermScheduleValue(TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new MonthScheduleValue((ResultCode)ArticleResultCode.RESULT_VALUE_TERM_MONTH_HOURS, hoursMonth);

            ResultValues = ResultValues.Concat(value);

            return this;
        }

        public IArticleResult AddMonthAttendanceScheduleValue(TDay dayFrom, TDay dayStop, TSeconds[] hoursMonth)
        {
            IArticleResultValues value = new MonthAttendanceValue(
                (ResultCode)ArticleResultCode.RESULT_VALUE_ATTN_MONTH_HOURS, 
                dayFrom, dayStop, hoursMonth);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddMoneyPaymentValue(TAmount payment)
        {
            IArticleResultValues value = new MoneyPaymentValue((ResultCode)ArticleResultCode.RESULT_VALUE_PAYMENT_MONEY, payment);

            ResultValues = ResultValues.Concat(value);

            return this;
        }

        public IArticleResult AddDeclarationTaxingValue(Byte statement, WorkTaxingTerms summarize, Byte declaracy, Byte residency)
        {
            IArticleResultValues value = new DeclarationTaxingValue(statement, summarize, declaracy, residency);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddDeclarationHealthValue(Byte statement, WorkHealthTerms summarize, TAmount totalBase, Byte foreigner)
        {
            IArticleResultValues value = new DeclarationHealthValue(statement, summarize, totalBase, foreigner);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddDeclarationSocialValue(Byte statement, WorkSocialTerms summarize, TAmount totalBase, Byte foreigner)
        {
            IArticleResultValues value = new DeclarationSocialValue(statement, summarize, totalBase, foreigner);

            ResultValues = ResultValues.Concat(value);

            return this;
        }

        public IArticleResult AddIncomeTaxGeneralValue(WorkTaxingTerms summarize, Byte statement, Byte residency,
            TAmount related, TAmount agrtask, TAmount partner, TAmount exclude)
        {
            IArticleResultValues value = new IncomeTaxGeneralValue(summarize, statement, residency, related, agrtask, partner,  exclude);

            ResultValues = ResultValues.Concat(value);

            return this;
        }

        public IArticleResult AddIncomeInsHealthValue(WorkHealthTerms summarize, TAmount related, TAmount exclude)
        {
            IArticleResultValues value = new IncomeInsHealthValue(summarize, related, exclude);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
        public IArticleResult AddIncomeInsSocialValue(WorkSocialTerms summarize, TAmount related, TAmount exclude)
        {
            IArticleResultValues value = new IncomeInsSocialValue(summarize, related, exclude);

            ResultValues = ResultValues.Concat(value);

            return this;
        }
 
        protected ConfigProp InternalConfig { get; set; }
        protected ResultValuesStore ResultValues { get; set; }

        public ConfigBase Config()
        {
            return InternalConfig;
        }
        public ConfigCode Code()
        {
            return InternalConfig.Code();
        }
        public ConfigRole Role()
        {
            return InternalConfig.Role();
        }
        public ConfigGang Gang()
        {
            return InternalConfig.Gang();
        }
        public ConfigType Type()
        {
            return InternalConfig.Type();
        }
        public ConfigBind Bind()
        {
            return InternalConfig.Bind();
        }

        public bool IsTaxingIncome()
        {
            return InternalConfig.IsTaxingIncome();
        }
        public bool IsTaxingPartner()
        {
            return InternalConfig.IsTaxingPartner();
        }
        public bool IsTaxingExclude()
        {
            return InternalConfig.IsTaxingExclude();
        }
        public bool IsHealthIncome()
        {
            return InternalConfig.IsHealthIncome();
        }
        public bool IsHealthExclude()
        {
            return InternalConfig.IsHealthExclude();
        }
        public bool IsSocialIncome()
        {
            return InternalConfig.IsSocialIncome();
        }
        public bool IsSocialExclude()
        {
            return InternalConfig.IsSocialExclude();
        }

        public object Clone()
        {
            ArticleGeneralResult cloneResult = (ArticleGeneralResult)this.MemberwiseClone();
            cloneResult.InternalConfig = CloneUtils<ConfigProp>.CloneOrNull(InternalConfig);
            cloneResult.ResultValues = CloneUtils<ResultValuesStore>.CloneOrNull(ResultValues);

            return cloneResult;
        }

        public override string ToString()
        {
            string articleCode = ArticleCodeAdapter.GetSymbol(InternalConfig.Code());

            string articleDesc = string.Join("\r\n", ResultValues.Select((v) => (v.Description())));

            return string.Format("{0}\r\n{1}", articleCode, articleDesc);
        }
        public Maybe<T> ReturnValue<T>(Func<IArticleResultValues, bool> filterFunc) where T : class, IArticleResultValues
        {
            IArticleResultValues generalvalue = ResultValues.SingleOrDefault(filterFunc);
            T value = generalvalue as T;
            if (value == null)
            {
                return Maybe<T>.Nothing;
            }
            return Maybe.From<T>(value);
        }
        public Maybe<T> ReturnValueForResultCode<T>(ResultCode filterCode) where T : class, IArticleResultValues
        {
            return ReturnValue<T>((x) => (x.IsResultCodeValue(filterCode)));
        }
        public Maybe<ContractFromStopValue> ReturnContractTermFromStopValue()
        {
            return ReturnValue<ContractFromStopValue>((v) => (v.IsContractFromStopValue()));
        }
        public Maybe<PositionFromStopValue> ReturnPositionTermFromStopValue()
        {
            return ReturnValue<PositionFromStopValue>((v) => (v.IsPositionFromStopValue()));
        }
        public Maybe<MonthFromStopValue> ReturnMonthFromStopValue()
        {
            return ReturnValue<MonthFromStopValue>((v) => (v.IsMonthFromStopValue()));
        }
        public Maybe<MonthScheduleValue> ReturnFullMonthValue()
        {
            return ReturnValue<MonthScheduleValue>((v) => (v.IsFullMonthValue()));
        }
        public Maybe<MonthScheduleValue> ReturnRealMonthValue()
        {
            return ReturnValue<MonthScheduleValue>((v) => (v.IsRealMonthValue()));
        }
        public Maybe<MonthScheduleValue> ReturnTermMonthValue()
        {
            return ReturnValue<MonthScheduleValue>((v) => (v.IsTermMonthValue()));
        }
        public Maybe<MonthAttendanceValue> ReturnMonthAttendanceValue()
        {
            return ReturnValue<MonthAttendanceValue>((v) => (v.IsMonthAttendanceValue()));
        }
    }
}
