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

    public class TaxDeclarationSource : ISourceValues, ICloneable
    {
        public Byte StatementType { get; set; }
        public WorkTaxingTerms SummarizeType { get; set; }
        public Byte DeclaracyType { get; set; }
        public Byte ResidencyType { get; set; }

        public TaxDeclarationSource()
        {
            StatementType = 0;
            SummarizeType = WorkTaxingTerms.TAXING_TERM_EMPLOYMENT;
            DeclaracyType = 0;
            ResidencyType = 0;
        }

        public TaxDeclarationSource(Byte statementType, WorkTaxingTerms summarizeType, Byte declaracyType, Byte residencyType)
        {
            StatementType = statementType;
            SummarizeType = summarizeType;
            DeclaracyType = declaracyType;
            ResidencyType = residencyType;
        }

        public virtual object Clone()
        {
            TaxDeclarationSource cloneSource = (TaxDeclarationSource)this.MemberwiseClone();

            cloneSource.StatementType = this.StatementType;
            cloneSource.SummarizeType = this.SummarizeType;
            cloneSource.DeclaracyType = this.DeclaracyType;
            cloneSource.ResidencyType = this.ResidencyType;

            return cloneSource;
        }

    }
}
