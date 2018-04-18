using System;
using System.Linq;

namespace ElementsLib.Service.Elements
{
    using Module.Interfaces.Matrixus;
    using ElementsLib.Elements;
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
