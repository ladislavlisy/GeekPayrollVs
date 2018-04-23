using System;

namespace ElementsLib.Elements.Config.Results
{
    using Module.Interfaces.Elements;
    public abstract class GeneralResultValue : IArticleResultValues
    {
        public abstract string Description();

        public virtual bool IsWorkWeekValue()
        {
            return false;
        }
        public virtual bool IsMonthFromStopValue()
        {
            return false;
        }
        public virtual bool IsWorkMonthValue()
        {
            return false;
        }
    }
}