using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ElementsLib
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using ExtendedCode = UInt16;
    using ExtendedSeed = UInt16;

    using Interfaces;

    public abstract class AbstractArticleBucket
    {
        IDictionary<ArticleTarget, IArticleSource> model; 

        Assembly configAssembly = typeof(ElementsModule).Assembly;

        public AbstractArticleBucket()
        {
            model = new Dictionary<ArticleTarget, IArticleSource>();
        }

        public ArticleTarget AddContractTarget()
        {
            ContractCode CONTRACT_CODE = TargetConst.CONTRACT_CODE_NULL;
            PositionCode POSITION_CODE = TargetConst.POSITION_CODE_NULL;
            ExtendedCode ARTICLE_CODE = GetContractArticleCode();

            return AddGeneralItem(CONTRACT_CODE, POSITION_CODE, ARTICLE_CODE, TargetConst.TARGET_SEED_NULL);
        }

        internal abstract ExtendedCode GetContractArticleCode();

        public ArticleTarget AddPositionTarget(ContractCode contract)
        {
            PositionCode POSITION_CODE = TargetConst.POSITION_CODE_NULL;
            ExtendedCode ARTICLE_CODE = GetPositionArticleCode();

            return AddGeneralItem(contract, POSITION_CODE, ARTICLE_CODE, TargetConst.TARGET_SEED_NULL);
        }

        internal abstract ExtendedCode GetPositionArticleCode();

        public ArticleTarget AddContractItem(ContractCode contract, ExtendedCode code)
        {
            PositionCode POSITION_CODE = TargetConst.POSITION_CODE_NULL;

            return AddGeneralItem(contract, POSITION_CODE, code, TargetConst.TARGET_SEED_NULL);
        }
        public ArticleTarget AddPositionItem(ContractCode contract, PositionCode position, ExtendedCode code)
        {
            return AddGeneralItem(contract, position, code, TargetConst.TARGET_SEED_NULL);
        }
        public ArticleTarget AddGeneralItem(ContractCode contract, PositionCode position, ExtendedCode code, ExtendedSeed seed)
        {
            ExtendedSeed newTargetSeed = TargetSelector.GetSeedToNewTarget(model.Keys, contract, position, code);

            ArticleTarget newTarget = new ArticleTarget(contract, position, code, newTargetSeed);

            IArticleSource newSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, GetSymbol(code));

            model.Add(newTarget, newSource);

            return newTarget;
        }
        public ArticleTarget StoreGeneralItem(ContractCode contract, PositionCode position, ExtendedCode code, ExtendedSeed seed)
        {
            ArticleTarget newTarget = new ArticleTarget(contract, position, code, seed);

            IArticleSource newSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, GetSymbol(code));

            model.Add(newTarget, newSource);

            return newTarget;
        }

        internal abstract string GetSymbol(ExtendedCode code);
    }
}
