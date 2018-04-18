using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus
{
    using ConfigCode = UInt16;
    using TargetItem = Module.Interfaces.Elements.IArticleTarget;

    using CodeItem = Module.Interfaces.Permadom.ArticleCodeConfigData;
    using RoleItem = Module.Interfaces.Permadom.ArticleRoleConfigData;

    using CodeList = IEnumerable<Module.Interfaces.Permadom.ArticleCodeConfigData>;
    using RoleList = IEnumerable<Module.Interfaces.Permadom.ArticleRoleConfigData>;

    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourceErrs = String;

    using Module.Interfaces.Matrixus;
    using Module.Interfaces.Elements;
    using Config;
    using System.Reflection;

    public class ArticleConfigProfile : IArticleConfigProfile
    {
        protected IArticleMasterCollection InternalRoles { get; set; }
        protected IArticleDetailCollection InternalCodes { get; set; }

        public ArticleConfigProfile()
        {
            InternalRoles = new ArticleMasterCollection();
            InternalCodes = new ArticleDetailCollection();
        }

        public void Initialize(Assembly configAssembly, RoleList configRoleData, CodeList configCodeData, IArticleConfigFactory configFactory)
        {
            InternalRoles.LoadConfigData(configAssembly, configRoleData, configFactory);

            InternalCodes.LoadConfigData(InternalRoles, configCodeData, configFactory);

            //IEnumerable<KeyValuePair<UInt16, Module.Interfaces.Elements.IArticleConfig>>
            //IEnumerable<Module.Interfaces.Elements.IArticleConfig> LoadConfigData

            //InternalSource.InitConfigModel(configAssembly, articleSourceFactory);
            //InternalSource.InitConfigModel(**LoadConfigData, configAssembly, articleSourceFactory);


        }
        public IEnumerable<TargetItem> GetTargets(IEnumerable<TargetItem> targetsInit, ConfigCode headCode, ConfigCode partCode)
        {
            return InternalCodes.GetTargets(targetsInit, headCode, partCode);
        }

        public IList<KeyValuePair<ConfigCode, Int32>> ModelPath()
        {
            return InternalCodes.ModelPath();
        }

        public ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals)
        {
            return InternalCodes.CloneInstanceForCode(configCode, sourceVals);
        }
    }
}
