using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ElementsLib.Matrixus
{
    using CodeItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using RoleItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using CodeList = IEnumerable<Module.Interfaces.Permadom.ArticleCodeConfigData>;
    using RoleList = IEnumerable<Module.Interfaces.Permadom.ArticleRoleConfigData>;

    using Config;
    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;

    public class MatrixusService : IMatrixusService
    {
        protected Assembly ModuleAssembly { get; set; }
        protected IArticleConfigFactory InternalConfigFactory { get; set; }
        protected IArticleConfigProfile InternalConfigProfile { get; set; }

        protected MatrixusService()
        {
            InternalConfigFactory = null;
            InternalConfigProfile = null;
        }

        public MatrixusService(IArticleConfigFactory configFactory, IArticleConfigProfile configProfile)
        {
            InternalConfigFactory = configFactory;

            InternalConfigProfile = configProfile;
        }

        public void Initialize(RoleList configRoleData, CodeList configCodeData)
        {
            InternalConfigProfile.Initialize(ModuleAssembly, configRoleData, configCodeData, InternalConfigFactory);
        }

        public IArticleConfigProfile Profile()
        {
            return InternalConfigProfile;
        }

    }
}
