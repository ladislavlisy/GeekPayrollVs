using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;
    using Module.Json;
    using Module.Libs;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class InsDeclarationHealthSource : ISourceValues, ICloneable
    {
        public Byte StatementType { get; set; }
        public WorkHealthTerms SummarizeType { get; set; }

        public InsDeclarationHealthSource()
        {
            StatementType = 0;
            SummarizeType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENT;
        }

        public InsDeclarationHealthSource(Byte statementType, WorkHealthTerms summarizeType)
        {
            StatementType = statementType;
            SummarizeType = summarizeType;
        }

        public virtual object Clone()
        {
            InsDeclarationHealthSource cloneSource = (InsDeclarationHealthSource)this.MemberwiseClone();

            cloneSource.StatementType = this.StatementType;
            cloneSource.SummarizeType = this.SummarizeType;

            return cloneSource;
        }

    }
}
