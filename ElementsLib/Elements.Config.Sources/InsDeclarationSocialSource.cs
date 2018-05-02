using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements.Config.Sources
{
    using Legalist.Constants;
    using Module.Interfaces.Elements;

    public class InsDeclarationSocialSource : ISourceValues, ICloneable
    {
        public Byte StatementType { get; set; }
        public WorkSocialTerms SummarizeType { get; set; }

        public InsDeclarationSocialSource()
        {
            StatementType = 0;
            SummarizeType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;
        }

        public InsDeclarationSocialSource(Byte statementType, WorkSocialTerms summarizeType)
        {
            StatementType = statementType;
            SummarizeType = summarizeType;
        }

        public virtual object Clone()
        {
            InsDeclarationSocialSource cloneSource = (InsDeclarationSocialSource)this.MemberwiseClone();

            cloneSource.StatementType = this.StatementType;
            cloneSource.SummarizeType = this.SummarizeType;

            return cloneSource;
        }

    }
}
