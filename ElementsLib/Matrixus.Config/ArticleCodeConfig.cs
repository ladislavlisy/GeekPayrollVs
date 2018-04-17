using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using SymbolName = String;

    using Module.Interfaces.Elements;
    using Module.Codes;

    // ArticleConfig = 
    // ArticleCode, 
    // ConceptCode, 
    // ArticleVals, 
    // ResolveCodes, xx 
    // SummaryCodes, 
    // IncomesRules
    // Create ArticleSource

    public class ArticleCodeConfig : IArticleCodeConfig
    {
        public ArticleCodeConfig(ConfigCode code, ConfigRole role, ConfigType type, SymbolName name, params ConfigCode[] path)
        {
            InternalCode = code;
            InternalRole = role;
            InternalType = type;
            InternalName = name;
            InternalPath = path.ToList();
        }

        protected ConfigCode InternalCode { get; set; }
        protected ConfigRole InternalRole { get; set; }
        protected ConfigType InternalType { get; set; } 
        protected SymbolName InternalName { get; set; } 
        protected IList<ConfigCode> InternalPath { get; set; }
        protected IArticleSource InternalStub { get; set; } 

        public ConfigCode Code()
        {
            return InternalCode;
        }
        public ConfigRole Role()
        {
            return InternalRole;
        }
        public ConfigType Type()
        {
            return InternalType;
        }
        public SymbolName Name()
        {
            return InternalName;
        }
        public ConfigCode[] Path()
        {
            return InternalPath.ToArray();
        }
        public void SetSymbolCode(ConfigCode _code, ConfigType _type, params ConfigCode[] _path)
        {
            InternalCode = _code;
            InternalType = _type;
            InternalPath = _path.ToList();
        }
        public void SetSymbolRole(ConfigRole _role)
        {
            InternalRole = _role;
        }

        public override string ToString()
        {
            return InternalName; // ArticleCodeAdapter.GetSymbol(InternalCode);
        }
    }
}
