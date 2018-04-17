using System;

namespace ElementsLib.Matrixus
{
    using Config;
    using Elements;
    using Source;
    public class SimpleMatrixusService : MatrixusService
    {
        public SimpleMatrixusService() : base()
        {
            ModuleAssembly = typeof(ElementsService).Assembly;

            InternalConfigFactory = new ArticleConfigFactory();
            InternalSourceFactory = new ArticleSourceFactory();

            InternalConfigProfile = new ArticleConfigProfile();
        }
    }
}
