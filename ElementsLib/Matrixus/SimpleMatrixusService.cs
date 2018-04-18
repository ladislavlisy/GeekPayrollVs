using System;
using System.Linq;

namespace ElementsLib.Matrixus
{
    using Config;
    using Elements;
    using Permadom;

    public class SimpleMatrixusService : MatrixusService
    {
        public SimpleMatrixusService() : base()
        {
            ModuleAssembly = typeof(ElementsService).Assembly;

            InternalConfigFactory = new ArticleConfigFactory();

            InternalConfigProfile = new ArticleConfigProfile();
        }

        public void InitializeService()
        {
            var configMemoryDb = new SimplePermadomService();

            var configCodeData = configMemoryDb.GetArticleCodeData().ToList();

            var configRoleData = configMemoryDb.GetArticleRoleData().ToList();

            Initialize(configRoleData, configCodeData);
        }
    }
}
