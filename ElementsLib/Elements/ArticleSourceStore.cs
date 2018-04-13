using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace ElementsLib.Elements
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;
    using BodySort = UInt16;

    using SourceCase = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;
    using TargetVals = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using TargetItem = Module.Interfaces.Elements.IArticleTarget;

    using SortedPair = KeyValuePair<UInt16, Int32>;
    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;

    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
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
        protected IDictionary<TargetItem, SourcePack> model;

        public IEnumerator<KeyValuePair<TargetItem, SourcePack>> GetEnumerator()
        {
            return model.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return model.GetEnumerator();
        }
        public ICollection<TargetItem> Keys
        {
            get { return model.Keys; }
        }
        public IEnumerable<TargetItem> GetTargets()
        {
            return model.Keys.ToList();
        }

        public IEnumerable<KeyValuePair<TargetItem, SourcePack>> GetModel()
        {
            return model.ToList();
        }

        #endregion

        public ArticleSourceStore(SourceCase sourceBundler)
        {
            model = new Dictionary<TargetItem, SourcePack>();

            ModelSourceBundler = sourceBundler;
        }

        public void CopyModel(IArticleSourceStore source)
        {
            model = source.GetModel().ToDictionary((kv) => (kv.Key), (kv) => (kv.Value));
        }
        public void AddGeneralItems(IEnumerable<TargetItem> targets)
        {
            foreach (var calc in targets)
            {
                if (Keys.SingleOrDefault((s) => (s.IsEqualToHeadPartCode(calc))) == null)
                {
                    AddGeneralItem(calc.Head(), calc.Part(), calc.Code(), calc.Seed(), null);
                }
            }
        }

        public BodyCode GetHeadBodyCode()
        {
            return Module.Codes.ArticleCodeAdapter.GetContractCode();
        }

        public TargetItem AddMainHead(ISourceValues tagsBody)
        {
            HeadCode HEAD_CODE = ArticleTarget.HEAD_CODE_NULL;
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;
            BodyCode BODY_CODE = GetHeadBodyCode();

            return AddGeneralItem(HEAD_CODE, PART_CODE, BODY_CODE, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }

        public BodyCode GetPartBodyCode()
        {
            return Module.Codes.ArticleCodeAdapter.GetPositionCode();
        }

        public TargetItem AddMainPart(HeadCode codeHead, ISourceValues tagsBody)
        {
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;
            BodyCode BODY_CODE = GetPartBodyCode();

            return AddGeneralItem(codeHead, PART_CODE, BODY_CODE, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }

        public TargetItem AddHeadItem(HeadCode codeHead, BodyCode codeBody, ISourceValues tagsBody)
        {
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;

            return AddGeneralItem(codeHead, PART_CODE, codeBody, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }
        public TargetItem AddPartItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, ISourceValues tagsBody)
        {
            return AddGeneralItem(codeHead, codePart, codeBody, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }
        public TargetItem AddGeneralItem(TargetItem target, ISourceValues tagsBody)
        {
            return AddGeneralItem(target.Head(), target.Part(), target.Code(), target.Seed(), tagsBody);
        }
        public TargetItem AddGeneralItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody, ISourceValues tagsBody)
        {
            BodySeed newBodySeed = TargetSelector.GetSeedToNewTarget(model.Keys, codeHead, codePart, codeBody);

            return StoreGeneralItem(codeHead, codePart, codeBody, newBodySeed, tagsBody);
        }
        public TargetItem StoreGeneralItem(TargetItem target, ISourceValues tagsBody)
        {
            return StoreGeneralItem(target.Head(), target.Part(), target.Code(), target.Seed(), tagsBody);
        }
        public TargetItem StoreGeneralItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody, ISourceValues tagsBody)
        {
            ArticleTarget newTarget = new ArticleTarget(codeHead, codePart, codeBody, seedBody);

            SourcePack newSource = GetTemplateSourceForArticle(codeBody, tagsBody);

            model.Add(newTarget, newSource);

            return newTarget;
        }
        protected SourcePack GetTemplateSourceForArticle(BodyCode codeBody, ISourceValues tagsBody)
        {
            if (ModelSourceBundler == null)
            {
                return Result.Fail<IArticleSource, string>(EXCEPTION_CONFIG_NULL_TEXT);
            }
            return ModelSourceBundler.CloneInstanceForCode(codeBody, tagsBody);
        }
        public IList<SourcePair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler, BodyCode contractCode, BodyCode positionCode)
        {
            IEnumerable<TargetItem> targetsInit = GetTargets();
            IEnumerable<TargetItem> targetsCalc = configBundler.GetTargets(targetsInit, contractCode, positionCode);
            IList<SortedPair> modelPath = configBundler.ModelPath();

            AddGeneralItems(targetsCalc);

            IList<TargetItem> sortedTargets = Keys.OrderBy((x) => (x), new CompareEvaluationTargets(modelPath)).ToList();

            return sortedTargets.Select((s) => (model.SingleOrDefault((kv) => (kv.Key.CompareTo(s) == 0)))).ToList();
        }
    }

    internal class CompareEvaluationTargets : IComparer<TargetItem>
    {
        private IList<SortedPair> ModelOrderList;

        public CompareEvaluationTargets(IList<SortedPair> modelOrderList)
        {
            this.ModelOrderList = modelOrderList;
        }

        public int Compare(TargetItem x, TargetItem y)
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
