﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using BodyCode = UInt16;
    using BodyRole = UInt16;
    using MarkCode = Module.Codes.ArticleCzCode;

    using Module.Interfaces.Elements;
    using Module.Codes;

    // ArticleConfig = 
    // ArticleCode, 
    // ConceptCode, 
    // ArticleVals, 
    // ResolveCodes, xx 
    // SummaryCodes, 
    // IncomesRules
    // Create ArticleSource

    public class ArticleConfig : IArticleConfig
    {
        public ArticleConfig(BodyCode codeBody, BodyRole roleBody, params BodyCode[] codePath)
        {
            InternalCode = codeBody;
            InternalRole = roleBody;
            ResolvePath = codePath.ToList();
        }

        protected BodyCode InternalCode { get; set; }
        protected BodyRole InternalRole { get; set; }
        protected IList<BodyCode> ResolvePath { get; set; }

        public BodyCode Code()
        {
            return InternalCode;
        }
        public BodyRole Role()
        {
            return InternalRole;
        }
        public BodyCode[] Path()
        {
            return ResolvePath.ToArray();
        }

        public override string ToString()
        {
            MarkCode symbol = ArticleCodeAdapter.CreateEnum(InternalCode);

            return symbol.GetSymbol();
        }
    }
}
