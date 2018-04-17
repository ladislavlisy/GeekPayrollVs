using ElementsLib.Module.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Config
{
    using ConfigRole = UInt16;
    using SymbolName = String;

    public class ArticleRoleConfig : IArticleRoleConfig
    {
        public ArticleRoleConfig(ConfigRole role, SymbolName name, params ConfigRole[] path)
        {
            InternalRole = role;
            InternalName = name;
            InternalPath = path.ToList();
        }

        protected ConfigRole InternalRole { get; set; }
        protected SymbolName InternalName { get; set; }
        protected IList<ConfigRole> InternalPath { get; set; }
        protected IArticleSource InternalStub { get; set; }

        public ConfigRole Role()
        {
            return InternalRole;
        }
        public SymbolName Name()
        {
            return InternalName;
        }
        public ConfigRole[] Path()
        {
            return InternalPath.ToArray();
        }

        public override string ToString()
        {
            return InternalName; // ArticleRoleAdapter.GetSymbol(InternalRole);
        }
    }
}
