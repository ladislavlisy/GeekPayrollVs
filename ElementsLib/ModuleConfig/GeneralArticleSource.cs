using System;

namespace ElementsLib
{
    using ExtendedCode = PayrollCzCode;

    using Interfaces;
    public class GeneralArticleSource : IArticleSource
    {
        public GeneralArticleSource(ExtendedCode code)
        {
            Code = code;
        }

        public ExtendedCode Code { get; protected set; }

        public override string ToString()
        {
            return Code.GetSymbol();
        }
    }
}
