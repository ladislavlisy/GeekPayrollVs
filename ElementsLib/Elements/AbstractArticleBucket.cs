using System;
using System.Collections.Generic;

namespace ElementsLib.Elements
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = UInt16;
    using TargetSeed = UInt16;

    using Module.Interfaces.Elements;
    using Libs;

    public abstract class AbstractArticleBucket
    {
        IDictionary<ArticleTarget, IArticleSource> model; 

        public AbstractArticleBucket()
        {
            model = new Dictionary<ArticleTarget, IArticleSource>();
        }

        public ArticleTarget AddContractTarget()
        {
            ContractCode CONTRACT_CODE = ArticleTarget.CONTRACT_CODE_NULL;
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = GetContractArticleCode();

            return AddGeneralItem(CONTRACT_CODE, POSITION_CODE, ARTICLE_CODE, ArticleTarget.SEED_NULL);
        }

        internal abstract TargetCode GetContractArticleCode();

        public ArticleTarget AddPositionTarget(ContractCode contract)
        {
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = GetPositionArticleCode();

            return AddGeneralItem(contract, POSITION_CODE, ARTICLE_CODE, ArticleTarget.SEED_NULL);
        }

        internal abstract TargetCode GetPositionArticleCode();

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

        internal abstract IArticleSource GetTemplateSourceForArticle(TargetCode code);

        internal abstract string GetSymbol(TargetCode code);
    }
}
