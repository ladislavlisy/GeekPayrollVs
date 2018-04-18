using System;
using NUnit.Framework;
using ElementsLib.Module.Codes;
using ElementsLib.Elements;
using ElementsLib.Elements.Config;
using ElementsLib.Module.Interfaces.Elements;

namespace ElementsTest
{
    using ConfigCodeEnum = ArticleCodeCz;

    using TargetHead = UInt16;
    using TargetPart = UInt16;
    using ConfigCode = UInt16;
    using TargetSeed = UInt16;

    using System.Reflection;
    using ElementsLib;
    using ElementsLib.Elements.Config.Source;
    using ElementsLib.Module.Interfaces.Matrixus;
    using ElementsLib.Matrixus;
    using ElementsLib.Module.Interfaces.Permadom;
    using ElementsLib.Permadom;
    using System.Linq;
    using ElementsLib.Matrixus.Config;

    [TestFixture]
    public class ArticleTargetsTests
    {
        const TargetHead HEAD_CODE_NULL = 0;
        const TargetPart PART_CODE_NULL = 0;

        const ConfigCode BODY_CODE_TEST = (UInt16)ConfigCodeEnum.FACT_UNKNOWN;
        const TargetSeed BODY_SEED_NULL = 0;

        [Test]
        public void Test_CreateArticleTarget()
        {
            IArticleTarget testArticle = new ArticleTarget(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL);
            string testArticleLabel = "0-0-FACT_UNKNOWN-0";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddTargetToEmptyDict()
        {
            IArticleConfigProfile configProfile = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configProfile);

            ISourceValues values = new ArticleEmptySource();

            IArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-FACT_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBack()
        {
            IArticleConfigProfile configProfile = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configProfile);

            const TargetSeed TestFirstSeed = 1;

            ISourceValues values = new ArticleEmptySource();

            IArticleTarget prepArticle = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestFirstSeed, values);

            IArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-FACT_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFront()
        {
            IArticleConfigProfile configProfile = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configProfile);

            const TargetSeed TestFirstSeed = 2;

            ISourceValues values = new ArticleEmptySource();

            IArticleTarget prepArticle = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestFirstSeed, values);

            IArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-FACT_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondTargetToDictBetween()
        {
            IArticleConfigProfile configProfile = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configProfile);

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 3;
            const TargetSeed TestSeed03 = 4;

            ISourceValues values = new ArticleEmptySource();

            IArticleTarget prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            IArticleTarget backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            IArticleTarget backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);

            IArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-FACT_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBackNonEmpty()
        {
            IArticleConfigProfile configProfile = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configProfile);

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 2;
            const TargetSeed TestSeed03 = 3;
            const TargetSeed TestSeed04 = 4;

            ISourceValues values = new ArticleEmptySource();

            IArticleTarget prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            IArticleTarget backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            IArticleTarget backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);
            IArticleTarget backArticle4 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed04, values);

            IArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-FACT_UNKNOWN-5";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFrontNonEmpty()
        {
            IArticleConfigProfile configProfile = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configProfile);

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 2;
            const TargetSeed TestSeed03 = 3;
            const TargetSeed TestSeed05 = 5;

            ISourceValues values = new ArticleEmptySource();

            IArticleTarget prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            IArticleTarget backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            IArticleTarget backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);
            IArticleTarget backArticle5 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed05, values);

            IArticleTarget testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-FACT_UNKNOWN-4";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }

        private static IArticleConfigProfile InitConfigModel()
        {
            Assembly configAssembly = typeof(ElementsService).Assembly;

            IArticleConfigFactory configFactory = new ArticleConfigFactory();

            IArticleConfigProfile configProfile = new ArticleConfigProfile();

            IPermadomService payrollMemDbs = new PermadomService();

            var configRoleData = payrollMemDbs.GetArticleRoleDataList().ToList();

            var configCodeData = payrollMemDbs.GetArticleCodeDataList().ToList();

            configProfile.Initialize(configAssembly, configRoleData, configCodeData, configFactory);

            return configProfile;
        }
    }
}