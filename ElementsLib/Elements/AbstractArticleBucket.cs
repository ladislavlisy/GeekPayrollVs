using System;
using System.Collections.Generic;

namespace ElementsLib.Elements
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = UInt16;
    using TargetSeed = UInt16;
    using SourceDict = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16>;

    using Module.Interfaces.Elements;
    using Libs;
    using Exceptions;
    using System.Reflection;

    public abstract class AbstractArticleBucket
    {
        SourceDict TemplateArticles { get; set; }

        IDictionary<ArticleTarget, IArticleSource> model; 

        public AbstractArticleBucket(SourceDict templates)
        {
            model = new Dictionary<ArticleTarget, IArticleSource>();

            TemplateArticles = templates;
        }

        public ArticleTarget AddContractTarget()
        {
            ContractCode CONTRACT_CODE = ArticleTarget.CONTRACT_CODE_NULL;
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = GetContractArticleCode();

            return AddGeneralItem(CONTRACT_CODE, POSITION_CODE, ARTICLE_CODE, ArticleTarget.SEED_NULL);
        }

        public abstract TargetCode GetContractArticleCode();

        public ArticleTarget AddPositionTarget(ContractCode contract)
        {
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = GetPositionArticleCode();

            return AddGeneralItem(contract, POSITION_CODE, ARTICLE_CODE, ArticleTarget.SEED_NULL);
        }

        public abstract TargetCode GetPositionArticleCode();

        public ArticleTarget AddContractItem(ContractCode contract, TargetCode code)
        {
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;

            return AddGeneralItem(contract, POSITION_CODE, code, ArticleTarget.SEED_NULL);
        }
        public ArticleTarget AddPositionItem(ContractCode contract, PositionCode position, TargetCode code)
        {
            return AddGeneralItem(contract, position, code, ArticleTarget.SEED_NULL);
        }
        public ArticleTarget AddGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed)
        {
            TargetSeed newTargetSeed = TargetSelector.GetSeedToNewTarget(model.Keys, contract, position, code);

            return StoreGeneralItem(contract, position, code, newTargetSeed);
        }
        public ArticleTarget StoreGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed)
        {
            ArticleTarget newTarget = new ArticleTarget(contract, position, code, seed);

            IArticleSource newSource = GetTemplateSourceForArticle(code);

            model.Add(newTarget, newSource);

            return newTarget;
        }

        protected IArticleSource GetTemplateSourceForArticle(TargetCode code)
        {
            if (TemplateArticles == null)
            {
                throw new NoneExistingConfig();
            }
            return TemplateArticles.CloneInstanceForCode(code);
        }
    }
}
