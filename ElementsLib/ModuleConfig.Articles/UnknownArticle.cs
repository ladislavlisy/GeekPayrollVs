﻿using System;

namespace ElementsLib.ModuleConfig.Articles
{
    using ArticleCode = Codes.ArticleCzCode;
    public class UnknownArticle : GeneralArticleSource
    {
        public UnknownArticle() : base(ArticleCode.ARTCODE_UNKNOWN)
        {

        }
    }
}
