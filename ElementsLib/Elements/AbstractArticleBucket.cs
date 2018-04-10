using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace ElementsLib.Elements
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;
    using BodySort = UInt16;

    using Stencils = Module.Interfaces.Elements.ISourceCollection<Module.Interfaces.Elements.IArticleSource, UInt16, Module.Interfaces.Elements.ISourceValues>;

    using Module.Interfaces.Elements;
    using Libs;
    using Exceptions;

    public abstract class AbstractArticleBucket : IEnumerable<KeyValuePair<ArticleTarget, IArticleSource>>
    {
        Stencils TemplateCollection { get; set; }

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

        public AbstractArticleBucket(Stencils templates)
        {
            model = new Dictionary<ArticleTarget, IArticleSource>();

            TemplateCollection = templates;
        }

        public ArticleTarget AddMainHead(ISourceValues tagsBody)
        {
            HeadCode HEAD_CODE = ArticleTarget.HEAD_CODE_NULL;
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;
            BodyCode BODY_CODE = GetHeadBodyCode();

            return AddGeneralItem(HEAD_CODE, PART_CODE, BODY_CODE, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }

        public abstract BodyCode GetHeadBodyCode();

        public ArticleTarget AddMainPart(HeadCode codeHead, ISourceValues tagsBody)
        {
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;
            BodyCode BODY_CODE = GetPartBodyCode();

            return AddGeneralItem(codeHead, PART_CODE, BODY_CODE, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }

        public abstract BodyCode GetPartBodyCode();

        public ArticleTarget AddHeadItem(HeadCode codeHead, BodyCode codeBody, ISourceValues tagsBody)
        {
            PartCode PART_CODE = ArticleTarget.PART_CODE_NULL;

            return AddGeneralItem(codeHead, PART_CODE, codeBody, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }
        public ArticleTarget AddPartItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, ISourceValues tagsBody)
        {
            return AddGeneralItem(codeHead, codePart, codeBody, ArticleTarget.BODY_SEED_NULL, tagsBody);
        }
        public ArticleTarget AddGeneralItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody, ISourceValues tagsBody)
        {
            BodySeed newBodySeed = TargetSelector.GetSeedToNewTarget(model.Keys, codeHead, codePart, codeBody);

            return StoreGeneralItem(codeHead, codePart, codeBody, newBodySeed, tagsBody);
        }
        public ArticleTarget StoreGeneralItem(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody, ISourceValues tagsBody)
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
    }
}
