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
        protected IArticleDetailCollection detailBundle { get; set; }

        public ArticleConfigProfile()
        {
            detailBundle = new ArticleDetailCollection();
        }

        public void Initialize(Assembly configAssembly, RoleList configRoleData, CodeList configCodeData, IArticleConfigFactory configFactory)
        {
            IArticleMasterCollection masterBundle = new ArticleMasterCollection();

            masterBundle.LoadConfigData(configAssembly, configRoleData, configFactory);

            detailBundle.LoadConfigData(masterBundle, configCodeData, configFactory);
        }
        public IEnumerable<TargetItem> GetTargets(IEnumerable<TargetItem> targetsInit, ConfigCode headCode, ConfigCode partCode)
        {
            return detailBundle.GetTargets(targetsInit, headCode, partCode);
        }

        public IList<KeyValuePair<ConfigCode, Int32>> ModelPath()
        {
            return detailBundle.ModelPath();
        }

        public ResultMonad.Result<SourceItem, SourceErrs> CloneInstanceForCode(ConfigCode configCode, SourceVals sourceVals)
        {
            return detailBundle.CloneInstanceForCode(configCode, sourceVals);
        }
    }
}
