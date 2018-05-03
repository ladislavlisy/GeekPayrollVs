using System;
using System.Collections.Generic;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    public interface IArticleReferenceSort<TGang, TCode>
    {
        TGang Gang();
        IEnumerable<TCode> Path();
        bool CodeInPath(TCode _code);
   }
}
