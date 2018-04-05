using System;
using NUnit.Framework;
using ElementsLib.Module.Codes;
using ElementsLib.Elements;
using ElementsLib.Elements.Config;
using ElementsLib.Module.Interfaces.Elements;

namespace ElementsTest
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;

    using ConfigCode = UInt16;
    using SymbolCode = ArticleCzCode;
    using TargetSeed = UInt16;
    using System.Reflection;
    using ElementsLib;
    using ElementsLib.Elements.Config.Source;

    [TestFixture]
    public class ArticleTargetsTests
    {
        const ContractCode CONTRACT_NULL = 0;
        const PositionCode POSITION_NULL = 0;

        const ConfigCode TARGET_CODE_TEST = (UInt16)SymbolCode.ARTCODE_UNKNOWN;
        const TargetSeed TARGET_SEED_NULL = 0;

        [Test]
        public void Test_CreateArticleTarget()
        {
            ArticleTarget testArticle = new ArticleTarget(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-0";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddTargetToEmptyDict()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBack()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const TargetSeed TestFirstSeed = 1;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestFirstSeed, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFront()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const TargetSeed TestFirstSeed = 2;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestFirstSeed, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictBetween()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 3;
            const TargetSeed TestSeed03 = 4;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed01, values);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed02, values);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed03, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBackNonEmpty()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 2;
            const TargetSeed TestSeed03 = 3;
            const TargetSeed TestSeed04 = 4;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed01, values);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed02, values);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed03, values);
            ArticleTarget backArticle4 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed04, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-5";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFrontNonEmpty()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleBucket testBucket = new ArticleBucket(configTemplate);

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 2;
            const TargetSeed TestSeed03 = 3;
            const TargetSeed TestSeed05 = 5;

            ISourceValues values = new ArticleEmptySource();

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed01, values);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed02, values);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed03, values);
            ArticleTarget backArticle5 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed05, values);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL, values);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-4";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }

        private static ISourceCollection<IArticleSource, ConfigCode, ISourceValues> InitConfigModel()
        {
            Assembly configAssembly = typeof(ElementsModule).Assembly;
            IArticleSourceFactory configFactory = new ArticleSourceFactory();
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = new ArticleSourceCollection();

            configTemplate.InitConfigModel(configAssembly, configFactory);

            return configTemplate;
        }
    }
}