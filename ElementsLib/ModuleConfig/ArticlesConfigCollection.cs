using ElementsLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib
{
    using SymbolName = String;

    public abstract class ArticlesConfigCollection<AIDX> : GeneralConfigCollection<IArticleSource, AIDX, UInt16>
    {
        public ArticlesConfigCollection() : base()
        {
        }

        public IArticleSource FindArticle(UInt16 articleCode)
        {
            IArticleSource articleModel = FindInstanceForCode(articleCode);

            return articleModel;
        }

        public IArticleSource ConfigureArticleModel(Assembly configAssembly, ArticleCode article, SymbolName concept)
        {
            // ArticleConfig = 
            // ArticleCode, 
            // ConceptCode, 
            // ArticleVals, 
            // ResolveCodes, xx 
            // SummaryCodes, 
            // IncomesRules
            // Create ArticleSource

            //IArticleSource articleInstance = GeneralPayrollArticle.CreateArticle(
            //    article, concept, category, pendingNames, summaryNames,
            //    taxingIncome, healthIncome, socialIncome, grossSummary, nettoSummary, nettoDeducts);

            //return ConfigureModel(articleInstance, article);
            return null;
        }

        #region implemented abstract members of GeneralCollection

        protected override IArticleSource InstanceFor(Assembly configAssembly, SymbolName configSymbol)
        {
            IArticleSource emptyArticle = ArticleSourceFactory.ArticleSourceFor(configAssembly, configSymbol);

            return emptyArticle;
        }

        #endregion
    }
}
