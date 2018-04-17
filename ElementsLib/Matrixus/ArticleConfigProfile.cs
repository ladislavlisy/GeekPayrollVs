using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus
{
    using CodeItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using RoleItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using CodeList = IEnumerable<Module.Interfaces.Permadom.ArticleCodeConfigData>;
    using RoleList = IEnumerable<Module.Interfaces.Permadom.ArticleRoleConfigData>;

    using Module.Interfaces.Matrixus;
    using Module.Interfaces.Elements;
    using Config;
    using Source;

    public class ArticleConfigProfile : IArticleConfigProfile
    {
        protected IArticleRoleCollection InternalRoles { get; set; }
        protected IArticleCodeCollection InternalCodes { get; set; }
        protected IArticleStubCollection InternalStubs { get; set; }

        public ArticleConfigProfile()
        {
            InternalRoles = new ArticleRoleCollection();
            InternalCodes = new ArticleCodeCollection();
            InternalStubs = new ArticleStubCollection();
        }

        public void Initialize(RoleList configRoleData, CodeList configCodeData, IArticleConfigFactory configFactory)
        {
            InternalRoles.LoadConfigData(configRoleData, configFactory);
            InternalCodes.LoadConfigData(configCodeData, configFactory);

            //IEnumerable<KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleConfig>>
            //IEnumerable<Module.Interfaces.Elements.IArticleConfig> LoadConfigData

            //InternalSource.InitConfigModel(configAssembly, articleSourceFactory);
            //InternalSource.InitConfigModel(**LoadConfigData, configAssembly, articleSourceFactory);


        }
    }
}
