using System;
using System.Collections.Generic;

namespace ElementsLib.Elements
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = UInt16;
    using TargetSeed = UInt16;
    using SourceDict = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;

    using Module.Interfaces.Elements;
    using Libs;
    using Exceptions;
    using System.Reflection;
    using System.Collections;

    public abstract class AbstractArticleBucket : IEnumerable<KeyValuePair<ArticleTarget, IArticleSource>>
    {
        SourceDict TemplateArticles { get; set; }

        #region TARGET_SOURCE_MODEL
        IDictionary<ArticleTarget, IArticleSource> model;

        public IEnumerator<KeyValuePair<ArticleTarget, IArticleSource>> GetEnumerator()
        {
            return model.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return model.GetEnumerator();
        }
        #endregion

        public AbstractArticleBucket(SourceDict templates)
        {
            model = new Dictionary<ArticleTarget, IArticleSource>();

            TemplateArticles = templates;
        }

        public ArticleTarget AddContractHead(ISourceValues values)
        {
            ContractCode CONTRACT_CODE = ArticleTarget.CONTRACT_CODE_NULL;
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = GetContractArticleCode();

            return AddGeneralItem(CONTRACT_CODE, POSITION_CODE, ARTICLE_CODE, ArticleTarget.SEED_NULL, values);
        }

        public abstract TargetCode GetContractArticleCode();

        public ArticleTarget AddPositionHead(ContractCode contract, ISourceValues values)
        {
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;
            TargetCode ARTICLE_CODE = GetPositionArticleCode();

            return AddGeneralItem(contract, POSITION_CODE, ARTICLE_CODE, ArticleTarget.SEED_NULL, values);
        }

        public abstract TargetCode GetPositionArticleCode();

        public ArticleTarget AddContractItem(ContractCode contract, TargetCode code, ISourceValues values)
        {
            PositionCode POSITION_CODE = ArticleTarget.POSITION_CODE_NULL;

            return AddGeneralItem(contract, POSITION_CODE, code, ArticleTarget.SEED_NULL, values);
        }
        public ArticleTarget AddPositionItem(ContractCode contract, PositionCode position, TargetCode code, ISourceValues values)
        {
            return AddGeneralItem(contract, position, code, ArticleTarget.SEED_NULL, values);
        }
        public ArticleTarget AddGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed, ISourceValues values)
        {
            TargetSeed newTargetSeed = TargetSelector.GetSeedToNewTarget(model.Keys, contract, position, code);

            return StoreGeneralItem(contract, position, code, newTargetSeed, values);
        }
        public ArticleTarget StoreGeneralItem(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed, ISourceValues values)
        {
            ArticleTarget newTarget = new ArticleTarget(contract, position, code, seed);

            IArticleSource newSource = GetTemplateSourceForArticle(code, values);

            model.Add(newTarget, newSource);

            return newTarget;
        }

        protected IArticleSource GetTemplateSourceForArticle(TargetCode code, ISourceValues values)
        {
            if (TemplateArticles == null)
            {
                throw new NoneExistingConfig();
            }
            return TemplateArticles.CloneInstanceForCode(code, values);
        }
    }
}
