﻿using ElementsLib.ModuleConfig.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Interfaces
{
    public interface IArticleConfigFactory
    {
        ArticleConfig CreateConfig(ArticleConfigJson configJson);
    }
}
