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
    using TargetVals = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;
    using TargetPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SortedPair = KeyValuePair<UInt16, Int32>;

    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;

    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using Module.Interfaces.Elements;
    using Libs;
    using Exceptions;
    using Module.Interfaces.Matrixus;
    using ResultMonad;

    public abstract class AbstractArticleBucket : IArticleBucket
    {
        public static string EXCEPTION_CONFIG_NULL_TEXT = "Config Collection doesn't exist!";

        Stencils TemplateCollection { get; set; }

        #region TARGET_SOURCE_MODEL
        protected IDictionary<IArticleTarget, SourcePack> model;

        public IEnumerator<KeyValuePair<IArticleTarget, SourcePack>> GetEnumerator()
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

        public IEnumerable<KeyValuePair<IArticleTarget, SourcePack>> GetModel()
        {
            return model.ToList();
        }

        #endregion

        public AbstractArticleBucket(Stencils templates)
        {
            model = new Dictionary<IArticleTarget, SourcePack>();

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

            SourcePack newSource = GetTemplateSourceForArticle(codeBody, tagsBody);

            model.Add(newTarget, newSource);

            return newTarget;
        }

        protected SourcePack GetTemplateSourceForArticle(BodyCode codeBody, ISourceValues tagsBody)
        {
            if (TemplateCollection == null)
            {
                return Result.Fail<IArticleSource, string>(EXCEPTION_CONFIG_NULL_TEXT);
            }
            return TemplateCollection.CloneInstanceForCode(codeBody, tagsBody);
        }
        public abstract IList<TargetPair> PrepareEvaluationPath(IConfigCollection<ConfigItem, ConfigCode> configBundler,
            ConfigCode contractCode, ConfigCode positionCode);
    }
}
