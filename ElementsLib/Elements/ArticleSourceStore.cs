using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace ElementsLib.Elements
{
    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using HolderSeed = UInt16;
    using HolderSort = UInt16;

    using SourceCase = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;
    using SourceVals = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using HolderItem = Module.Interfaces.Elements.IArticleHolder;

    using SortedPair = KeyValuePair<UInt16, Int32>;
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleCodeConfig;

    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleHolder, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using Module.Interfaces.Elements;
    using Libs;
    using Exceptions;
    using Module.Interfaces.Matrixus;
    using ResultMonad;

    public class ArticleSourceStore : IArticleSourceStore
    {
        public static string EXCEPTION_CONFIG_NULL_TEXT = "Config Collection doesn't exist!";

        SourceCase ModelSourceBundler { get; set; }

        #region TARGET_SOURCE_MODEL
        protected IDictionary<HolderItem, SourcePack> model;

        public IEnumerator<KeyValuePair<HolderItem, SourcePack>> GetEnumerator()
        {
            return model.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return model.GetEnumerator();
        }
        public ICollection<HolderItem> Keys
        {
            get { return model.Keys; }
        }
        public IEnumerable<HolderItem> GetHolders()
        {
            return model.Keys.ToList();
        }

        public IEnumerable<KeyValuePair<HolderItem, SourcePack>> GetModel()
        {
            return model.ToList();
        }

        #endregion

        public ArticleSourceStore(SourceCase sourceBundler)
        {
            model = new Dictionary<HolderItem, SourcePack>();

            ModelSourceBundler = sourceBundler;
        }

        public void CopyModel(IArticleSourceStore source)
        {
            model = source.GetModel().ToDictionary((kv) => (kv.Key), (kv) => (kv.Value));
        }
        public void AddGeneralItems(IEnumerable<HolderItem> targets)
        {
            foreach (var calc in targets)
            {
                if (Keys.SingleOrDefault((s) => (s.IsEqualToHeadHolderPart(calc))) == null)
                {
                    AddGeneralItem(calc.Head(), calc.Part(), calc.Code(), calc.Seed(), null);
                }
            }
        }

        public ConfigCode GetHeadConfigCode()
        {
            return Module.Codes.ArticleCodeAdapter.GetContractCode();
        }

        public HolderItem AddMainHead(ISourceValues tagsBody)
        {
            HolderHead HEAD_CODE = ArticleHolder.HEAD_CODE_NULL;
            HolderPart PART_CODE = ArticleHolder.PART_CODE_NULL;
            ConfigCode BODY_CODE = GetHeadConfigCode();

            return AddGeneralItem(HEAD_CODE, PART_CODE, BODY_CODE, ArticleHolder.BODY_SEED_NULL, tagsBody);
        }

        public ConfigCode GetPartConfigCode()
        {
            return Module.Codes.ArticleCodeAdapter.GetPositionCode();
        }

        public HolderItem AddMainPart(HolderHead codeHead, ISourceValues tagsBody)
        {
            HolderPart PART_CODE = ArticleHolder.PART_CODE_NULL;
            ConfigCode BODY_CODE = GetPartConfigCode();

            return AddGeneralItem(codeHead, PART_CODE, BODY_CODE, ArticleHolder.BODY_SEED_NULL, tagsBody);
        }

        public HolderItem AddHeadItem(HolderHead codeHead, ConfigCode codeBody, ISourceValues tagsBody)
        {
            HolderPart PART_CODE = ArticleHolder.PART_CODE_NULL;

            return AddGeneralItem(codeHead, PART_CODE, codeBody, ArticleHolder.BODY_SEED_NULL, tagsBody);
        }
        public HolderItem AddPartItem(HolderHead codeHead, HolderPart codePart, ConfigCode codeBody, ISourceValues tagsBody)
        {
            return AddGeneralItem(codeHead, codePart, codeBody, ArticleHolder.BODY_SEED_NULL, tagsBody);
        }
        public HolderItem AddGeneralItem(HolderItem target, ISourceValues tagsBody)
        {
            return AddGeneralItem(target.Head(), target.Part(), target.Code(), target.Seed(), tagsBody);
        }
        public HolderItem AddGeneralItem(HolderHead codeHead, HolderPart codePart, ConfigCode codeBody, HolderSeed seedBody, ISourceValues tagsBody)
        {
            HolderSeed newHolderSeed = HolderSelector.GetSeedToNewHolder(model.Keys, codeHead, codePart, codeBody);

            return StoreGeneralItem(codeHead, codePart, codeBody, newHolderSeed, tagsBody);
        }
        public HolderItem StoreGeneralItem(HolderItem target, ISourceValues tagsBody)
        {
            return StoreGeneralItem(target.Head(), target.Part(), target.Code(), target.Seed(), tagsBody);
        }
        public HolderItem StoreGeneralItem(HolderHead codeHead, HolderPart codePart, ConfigCode codeBody, HolderSeed seedBody, ISourceValues tagsBody)
        {
            ArticleHolder newHolder = new ArticleHolder(codeHead, codePart, codeBody, seedBody);

            SourcePack newSource = GetTemplateSourceForArticle(codeBody, tagsBody);

            model.Add(newHolder, newSource);

            return newHolder;
        }
        protected SourcePack GetTemplateSourceForArticle(ConfigCode codeBody, ISourceValues tagsBody)
        {
            if (ModelSourceBundler == null)
            {
                return Result.Fail<IArticleSource, string>(EXCEPTION_CONFIG_NULL_TEXT);
            }
            return ModelSourceBundler.CloneInstanceForCode(codeBody, tagsBody);
        }
        public IList<SourcePair> PrepareEvaluationPath(IArticleCodeCollection configBundler, ConfigCode contractCode, ConfigCode positionCode)
        {
            IEnumerable<HolderItem> holdersInit = GetHolders();
            IEnumerable<HolderItem> holdersCalc = configBundler.GetHolders(holdersInit, contractCode, positionCode);
            IList<SortedPair> modelPath = configBundler.ModelPath();

            AddGeneralItems(holdersCalc);

            IList<HolderItem> sortedHolders = Keys.OrderBy((x) => (x), new CompareEvaluationHolders(modelPath)).ToList();

            return sortedHolders.Select((s) => (model.SingleOrDefault((kv) => (kv.Key.CompareTo(s) == 0)))).ToList();
        }
    }

    internal class CompareEvaluationHolders : IComparer<HolderItem>
    {
        private IList<SortedPair> ModelOrderList;

        public CompareEvaluationHolders(IList<SortedPair> modelOrderList)
        {
            this.ModelOrderList = modelOrderList;
        }

        public int Compare(HolderItem x, HolderItem y)
        {
            if (x == y)
            {
                return 0;
            }

            SortedPair xResolve = ModelOrderList.SingleOrDefault((xk) => (xk.Key == x.Code()));

            Int32 xResolverOrder = 0;
            if (xResolve.Key == x.Code())
            {
                xResolverOrder = xResolve.Value;
            }

            SortedPair yResolve = ModelOrderList.SingleOrDefault((yk) => (yk.Key == y.Code()));

            Int32 yResolverOrder = 0;
            if (yResolve.Key == y.Code())
            {
                yResolverOrder = yResolve.Value;
            }

            int compareCode = xResolverOrder.CompareTo(yResolverOrder);
            if (compareCode != 0)
            {
                return compareCode;
            }
            compareCode = x.Head().CompareTo(y.Head());
            if (compareCode != 0)
            {
                return compareCode;
            }
            compareCode = x.Part().CompareTo(y.Part());
            if (compareCode != 0)
            {
                return compareCode;
            }
            compareCode = x.Seed().CompareTo(y.Seed());
            return compareCode;
        }
    }
}
