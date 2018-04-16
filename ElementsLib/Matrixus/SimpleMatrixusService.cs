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
            InternalConfig = new ArticleConfigCollection();

            InternalSourceFactory = new ArticleSourceFactory();
            InternalSource = new ArticleSourceCollection();
        }
    }
}
