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
    using TargetCode = ArticleCode;
    using TargetSeed = UInt16;

    public class ArticleBucket
    {
        IDictionary<ArticleTarget, IArticleSource> model; 

        Assembly configAssembly = typeof(ElementsModule).Assembly;

        public ArticleBucket()
        {
            model = new Dictionary<ArticleTarget, IArticleSource>();
        }

        public ArticleTarget AddContractTarget()
        {
            ContractCode CONTRACT_CODE = TargetConst.CONTRACT_CODE_NULL;
            PositionCode POSITION_CODE = TargetConst.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = TargetCode.ARTICLE_CONTRACT_TERM;

            return AddGeneralItem(CONTRACT_CODE, POSITION_CODE, ARTICLE_CODE, TargetConst.TARGET_SEED_NULL);
        }
        public ArticleTarget AddPositionTarget(ContractCode contract)
        {
            PositionCode POSITION_CODE = TargetConst.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = TargetCode.ARTICLE_POSITION_TERM;

            return AddGeneralItem(contract, POSITION_CODE, ARTICLE_CODE, TargetConst.TARGET_SEED_NULL);
        }
        public ArticleTarget AddContractItem(ContractCode contract, TargetCode code)
        {
            PositionCode POSITION_CODE = TargetConst.POSITION_CODE_NULL;

            return AddGeneralItem(contract, POSITION_CODE, code, TargetConst.TARGET_SEED_NULL);
        }
        public ArticleTarget AddPositionItem(ContractCode contract, PositionCode position, TargetCode code)
        {
            return AddGeneralItem(contract, position, code, TargetConst.TARGET_SEED_NULL);
        }
        public ArticleTarget AddGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed)
        {
            TargetSeed newTargetSeed = TargetSelector.GetSeedToNewTarget(model.Keys, contract, position, code);

            ArticleTarget newTarget = new ArticleTarget(contract, position, code, newTargetSeed);

            IArticleSource newSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, code.GetSymbol());

            model.Add(newTarget, newSource);

            return newTarget;
        }
        public ArticleTarget StoreGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed)
        {
            ArticleTarget newTarget = new ArticleTarget(contract, position, code, seed);

            IArticleSource newSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, code.GetSymbol());

            model.Add(newTarget, newSource);

            return newTarget;
        }
   }

}
