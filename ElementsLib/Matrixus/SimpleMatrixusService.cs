using System;

namespace ElementsLib.Matrixus
{
    using Config;
    using Elements;

    public class SimpleMatrixusService : MatrixusService
    {
        public SimpleMatrixusService() : base()
        {
            ModuleAssembly = typeof(ElementsService).Assembly;

            InternalConfigFactory = new ArticleConfigFactory();

            InternalConfigProfile = new ArticleConfigProfile();
        }
    }
}
