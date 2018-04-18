using System;

namespace ElementsLib.Service.Elements
{
    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;

    public class ElementsService : IElementsService
    {
        protected IArticleConfigProfile ConfigProfile { get; set; }

        protected IArticleSourceStore InternalSourceStore { get; set; }

        public IArticleSourceStore SourceStream()
        {
            return InternalSourceStore;
        }

        public ElementsService(IArticleConfigProfile configProfile)
        {
            this.ConfigProfile = configProfile;

            this.InternalSourceStore = null;
        }
    }
}
