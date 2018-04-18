using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Elements
{
    using Module.Interfaces;
    using Module.Interfaces.Matrixus;
    using Permadom;

    public class SimpleElementsService : ElementsService
    {
        public SimpleElementsService(IArticleConfigProfile configProfile) : base(configProfile)
        {
            InternalSourceStore = new ArticleSourceStore(configProfile);
        }

        public void InitializeService()
        {
            var streamMemoryDb = new SimplePermadomService();

            var sourceDataList = streamMemoryDb.GetArticleSourceData().ToList();

            sourceDataList.ForEach((s) => InternalSourceStore.StoreGeneralItem(s.Head, s.Part, s.Code, s.Seed, s.Tags));
        }
    }
}
