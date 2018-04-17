using System;

namespace ElementsLib.Matrixus
{
    using Config;
    using Source;
    public class SimpleMatrixusService : MatrixusService
    {
        public SimpleMatrixusService() : base()
        {
            InternalConfigFactory = new ArticleConfigFactory();
            InternalSourceFactory = new ArticleSourceFactory();

            InternalConfigProfile = new ArticleConfigProfile();
        }
    }
}
