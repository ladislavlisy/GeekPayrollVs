using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace ElementsLib.Elements
{
    using HolderItem = Module.Interfaces.Elements.IArticleHolder;
    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleHolder, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Interfaces.Elements;

    public class ArticleResultStore : IArticleResultStore
    {
        #region TARGET_SOURCE_MODEL
        protected IDictionary<HolderItem, ResultPack> model;

        public IEnumerator<ResultPair> GetEnumerator()
        {
            return model.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return model.GetEnumerator();
        }
        public ICollection<HolderItem> Keys
        {
            get { return model.Keys; }
        }
        public IEnumerable<HolderItem> GetHolders()
        {
            return model.Keys.ToList();
        }

        public IEnumerable<ResultPair> GetModel()
        {
            return model.ToList();
        }

        #endregion

        public ArticleResultStore()
        {
            model = new Dictionary<HolderItem, ResultPack>();
        }

        public void CopyModel(IArticleResultStore source)
        {
            model = source.GetModel().ToDictionary((kv) => (kv.Key), (kv) => (kv.Value));
        }
    }
}
