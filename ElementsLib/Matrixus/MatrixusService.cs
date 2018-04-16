using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus
{
    using Config;
    using Source;
    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;

    using ArticleCodeConfigItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using ArticleRoleConfigItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    public class MatrixusService : IMatrixusService
    {
        protected IArticleConfigFactory InternalConfigFactory { get; set; }
        protected IArticleSourceFactory InternalSourceFactory { get; set; }
        protected IArticleConfigCollection InternalConfig { get; set; }
        protected IArticleSourceCollection InternalSource { get; set; }
        //protected ArticleSourceCollection InternalMethod { get; set; }

        protected MatrixusService()
        {
            InternalConfigFactory = null;
            InternalConfig = null;

            InternalSourceFactory = null;
            InternalSource = null;
        }

        public MatrixusService(IArticleConfigFactory configFactory, IArticleSourceFactory sourceFactory,
            IArticleConfigCollection configCollection, IArticleSourceCollection sourceCollection)
        {
            InternalConfigFactory = new ArticleConfigFactory();
            InternalConfig = new ArticleConfigCollection();

            InternalSourceFactory = new ArticleSourceFactory();
            InternalSource = new ArticleSourceCollection();
        }

        public void Initialize(IEnumerable<ArticleCodeConfigItem> configCodeData)
        {
            //IEnumerable<KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleConfig>>
            //IEnumerable<Module.Interfaces.Elements.IArticleConfig> LoadConfigData

            InternalConfig.LoadConfigData(configCodeData, InternalConfigFactory);

            //InternalSource.InitConfigModel(configAssembly, articleSourceFactory);
            //InternalSource.InitConfigModel(**LoadConfigData, configAssembly, articleSourceFactory);

        }
    }
}
