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

    using Stencils = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;
    using TargetPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, Module.Interfaces.Elements.IArticleSource>;
    using SortedPair = KeyValuePair<UInt16, Int32>;

    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;

    using Module.Interfaces.Elements;
    using Libs;
    using Exceptions;
    using Module.Interfaces.Matrixus;
    using ResultMonad;
    using MaybeMonad;

    public abstract class AbstractArticleBucket : IArticleBucket
    {
        Stencils TemplateCollection { get; set; }

        #region TARGET_SOURCE_MODEL
        protected IDictionary<IArticleTarget, IArticleSource> model;

        public IEnumerator<KeyValuePair<IArticleTarget, IArticleSource>> GetEnumerator()
        {
            return model.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return model.GetEnumerator();
        }
        public ICollection<IArticleTarget> Keys
        {
            get { return model.Keys; }
        }
        public IEnumerable<IArticleTarget> GetTargets()
        {
            return model.Keys.ToList();
        }
        public IEnumerable<Result<IArticleTarget>> GetTargetsM()
        {
            return model.Keys.Select((a) => (Result.Ok<IArticleTarget>(a))).ToList();
        }

        public IEnumerable<KeyValuePair<IArticleTarget, IArticleSource>> GetModel()
        {
            return model.ToList();
        }

        #endregion

        public AbstractArticleBucket(Stencils templates)
        {
            model = new Dictionary<IArticleTarget, IArticleSource>();

            TemplateCollection = templates;
        }

        public void CopyTargets(IArticleBucket source)
        {
            model = source.GetModel().ToDictionary((kv) => (kv.Key), (kv) => (kv.Value));
        }
        public void ComplementTrace(IEnumerable<IArticleTarget> targets)
        {
            foreach (var calc in targets)
            {
                if (Keys.SingleOrDefault((s) => (s.IsEqualToHeadPartCode(calc))) == null)
                {
                    AddGeneralItem(calc.Head(), calc.Part(), calc.Code(), calc.Seed(), null);
                }
            }
        }

        public IArticleTarget AddMainHead(ISourceValues tagsBody)
        {
            HeadCode HEAD_CODE = ArticleTarget.HEAD_CODE_NULL;
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;
            BodyCode BODY_CODE = GetHeadBodyCode();

            return AddGeneralItem(HEAD_CODE, PART_CODE, BODY_CODE, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }

        public abstract BodyCode GetHeadBodyCode();

        public IArticleTarget AddMainPart(HeadCode codeHead, ISourceValues tagsBody)
        {
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;
            BodyCode BODY_CODE = GetPartBodyCode();

            return AddGeneralItem(codeHead, PART_CODE, BODY_CODE, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }

        public abstract BodyCode GetPartBodyCode();

        public IArticleTarget AddHeadItem(HeadCode codeHead, BodyCode codeBody, ISourceValues tagsBody)
        {
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;

            return AddGeneralItem(codeHead, PART_CODE, codeBody, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }
        public IArticleTarget AddPartItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, ISourceValues tagsBody)
        {
            return AddGeneralItem(codeHead, codePart, codeBody, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }
        public IArticleTarget AddGeneralItem(IArticleTarget target, ISourceValues tagsBody)
        {
            return AddGeneralItem(target.Head(), target.Part(), target.Code(), target.Seed(), tagsBody);
        }
        public IArticleTarget AddGeneralItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody, ISourceValues tagsBody)
        {
            BodySeed newBodySeed = TargetSelector.GetSeedToNewTarget(model.Keys, codeHead, codePart, codeBody);

            return StoreGeneralItem(codeHead, codePart, codeBody, newBodySeed, tagsBody);
        }
        public IArticleTarget StoreGeneralItem(IArticleTarget target, ISourceValues tagsBody)
        {
            return StoreGeneralItem(target.Head(), target.Part(), target.Code(), target.Seed(), tagsBody);
        }
        public IArticleTarget StoreGeneralItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody, ISourceValues tagsBody)
        {
            ArticleTarget newTarget = new ArticleTarget(codeHead, codePart, codeBody, seedBody);

            IArticleSource newSource = GetTemplateSourceForArticle(codeBody, tagsBody);

            model.Add(newTarget, newSource);

            return newTarget;
        }

        protected IArticleSource GetTemplateSourceForArticle(BodyCode codeBody, ISourceValues tagsBody)
        {
            if (TemplateCollection == null)
            {
                throw new NoneExistingConfig();
            }
            return TemplateCollection.CloneInstanceForCode(codeBody, tagsBody);
        }
        public abstract IList<TargetPair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler,
            ConfigCode contractCode, ConfigCode positionCode);
    }
}
