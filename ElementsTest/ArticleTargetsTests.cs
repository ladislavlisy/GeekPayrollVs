using System;
using NUnit.Framework;
using ElementsLib.Module.Codes;
using ElementsLib.Elements;
using ElementsLib.Elements.Config;
using ElementsLib.Module.Interfaces.Elements;

namespace ElementsTest
{
    using MarkCode = ArticleCzCode;

    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;

    using System.Reflection;
    using ElementsLib;
    using ElementsLib.Elements.Config.Source;

    [TestFixture]
    public class ArticleTargetsTests
    {
        const HeadCode HEAD_CODE_NULL = 0;
        const PartCode PART_CODE_NULL = 0;

        const BodyCode BODY_CODE_TEST = (UInt16)MarkCode.ARTCODE_UNKNOWN;
        const BodySeed BODY_SEED_NULL = 0;

        [Test]
        public void Test_CreateArticleTarget()
        {
            ArticleTarget testArticle = new ArticleTarget(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-0";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddTargetToEmptyDict()
        {
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBack()
        {
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const BodySeed TestFirstSeed = 1;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestFirstSeed, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFront()
        {
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const BodySeed TestFirstSeed = 2;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestFirstSeed, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictBetween()
        {
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const BodySeed TestSeed01 = 1;
            const BodySeed TestSeed02 = 3;
            const BodySeed TestSeed03 = 4;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBackNonEmpty()
        {
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const BodySeed TestSeed01 = 1;
            const BodySeed TestSeed02 = 2;
            const BodySeed TestSeed03 = 3;
            const BodySeed TestSeed04 = 4;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);
            ArticleTarget backArticle4 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed04, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-5";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFrontNonEmpty()
        {
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const BodySeed TestSeed01 = 1;
            const BodySeed TestSeed02 = 2;
            const BodySeed TestSeed03 = 3;
            const BodySeed TestSeed05 = 5;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);
            ArticleTarget backArticle5 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed05, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-4";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }

        private static ISourceCollection<IArticleSource, BodyCode, ISourceValues> InitConfigModel()
        {
            Assembly configAssembly = typeof(ElementsModule).Assembly;
            IArticleSourceFactory configFactory = new ArticleSourceFactory();
            ISourceCollection<IArticleSource, BodyCode, ISourceValues> configTemplate = new ArticleSourceCollection();

            configTemplate.InitConfigModel(configAssembly, configFactory);

            return configTemplate;
        }
    }
}