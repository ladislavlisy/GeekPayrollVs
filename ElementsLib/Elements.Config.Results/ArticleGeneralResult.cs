using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Results
{
    using ConfigCode = UInt16;

    using TDay = Byte;

    using Module.Interfaces.Elements;

    public class ArticleGeneralResult : IArticleResult
    {
        public ArticleGeneralResult(ConfigCode code, TDay dayFrom, TDay dayStop)
        {
            InternalCode = code;

            PeriodDayFrom = dayFrom;
            PeriodDayStop = dayStop;
        }
        public TDay PeriodDayFrom { get; protected set; }
        public TDay PeriodDayStop { get; protected set; }

        protected ConfigCode InternalCode { get; set; }
        public ConfigCode Code()
        {
            return InternalCode;
        }
        public object Clone()
        {
            ArticleGeneralResult cloneResult = (ArticleGeneralResult)this.MemberwiseClone();
            cloneResult.InternalCode = this.InternalCode;

            return cloneResult;
        }

        public override string ToString()
        {
            return string.Format("Result: Day FROM: {0}, Day STOP: {1}", 
                PeriodDayFrom.ToString(), PeriodDayStop.ToString());
        }
    }
}
