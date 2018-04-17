using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ConfigRole = UInt16;
    using SymbolName = String;

    public interface IArticleRoleConfig
    {
        ConfigRole Role();
        SymbolName Name();
        ConfigRole[] Path();
    }
}
