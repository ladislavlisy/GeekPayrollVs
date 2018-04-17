using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    using CodeList = IEnumerable<Permadom.ArticleCodeConfigData>;
    using RoleList = IEnumerable<Permadom.ArticleRoleConfigData>;

    using Elements;

    public interface IArticleConfigProfile
    {
        void Initialize(RoleList configRoleData, CodeList configCodeData, IArticleConfigFactory configFactory);
    }
}
