using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Elements
{
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleHolder, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    public interface IArticleResultStore : IEnumerable<KeyValuePair<IArticleHolder, ResultPack>>
    {
        IEnumerable<IArticleHolder> GetHolders();
        IEnumerable<ResultPair> GetModel();
    }
}
