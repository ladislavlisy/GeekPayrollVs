﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces
{
    using CodeList = IEnumerable<Module.Interfaces.Permadom.ArticleCodeConfigData>;
    using RoleList = IEnumerable<Module.Interfaces.Permadom.ArticleRoleConfigData>;

    using Matrixus;

    public interface IMatrixusService
    {
        void Initialize(RoleList configRoleData, CodeList configCodeDat);
        IArticleConfigProfile Profile();
    }
}
