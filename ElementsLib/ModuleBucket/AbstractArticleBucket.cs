using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ElementsLib.ModuleBucket
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = UInt16;
    using TargetSeed = UInt16;

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

            ArticleTarget newTarget = new ArticleTarget(contract, position, code, newTargetSeed);

            IArticleSource newSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, GetSymbol(code));

            model.Add(newTarget, newSource);

            return newTarget;
        }
        public ArticleTarget StoreGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed)
        {
            ArticleTarget newTarget = new ArticleTarget(contract, position, code, seed);

            IArticleSource newSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, GetSymbol(code));

            model.Add(newTarget, newSource);

            return newTarget;
        }

        internal abstract string GetSymbol(TargetCode code);
    }
}
