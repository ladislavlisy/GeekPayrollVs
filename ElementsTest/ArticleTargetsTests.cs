using System;
using NUnit.Framework;
using ElementsLib.Module.Codes;
using ElementsLib.Elements;
using ElementsLib.Elements.Config;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Matrixus.Source;

namespace ElementsTest
{
    using ConfigCodeEnum = ArticleCodeCz;

    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigCode = UInt16;
    using HolderSeed = UInt16;

    using System.Reflection;
    using ElementsLib;
    using ElementsLib.Elements.Config.Source;

    [TestFixture]
    public class ArticleHoldersTests
    {
        const HolderHead HEAD_CODE_NULL = 0;
        const HolderPart PART_CODE_NULL = 0;

        const ConfigCode BODY_CODE_TEST = (UInt16)ConfigCodeEnum.TARGET_UNKNOWN;
        const HolderSeed BODY_SEED_NULL = 0;

        [Test]
        public void Test_CreateArticleHolder()
        {
            IArticleHolder testArticle = new ArticleHolder(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-0";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddHolderToEmptyDict()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configTemplate);

            ISourceValues values = new ArticleEmptySource();

            IArticleHolder testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondHolderToDictToBack()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configTemplate);

            const HolderSeed TestFirstSeed = 1;

            ISourceValues values = new ArticleEmptySource();

            IArticleHolder prepArticle = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestFirstSeed, values);

            IArticleHolder testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondHolderToDictToFront()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configTemplate);

            const HolderSeed TestFirstSeed = 2;

            ISourceValues values = new ArticleEmptySource();

            IArticleHolder prepArticle = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestFirstSeed, values);

            IArticleHolder testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondHolderToDictBetween()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configTemplate);

            const HolderSeed TestSeed01 = 1;
            const HolderSeed TestSeed02 = 3;
            const HolderSeed TestSeed03 = 4;

            ISourceValues values = new ArticleEmptySource();

            IArticleHolder prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            IArticleHolder backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            IArticleHolder backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);

            IArticleHolder testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondHolderToDictToBackNonEmpty()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configTemplate);

            const HolderSeed TestSeed01 = 1;
            const HolderSeed TestSeed02 = 2;
            const HolderSeed TestSeed03 = 3;
            const HolderSeed TestSeed04 = 4;

            ISourceValues values = new ArticleEmptySource();

            IArticleHolder prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            IArticleHolder backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            IArticleHolder backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);
            IArticleHolder backArticle4 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed04, values);

            IArticleHolder testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-5";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }
        [Test]
        public void Test_AddSecondHolderToDictToFrontNonEmpty()
        {
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = InitConfigModel();

            ArticleSourceStore testBucket = new ArticleSourceStore(configTemplate);

            const HolderSeed TestSeed01 = 1;
            const HolderSeed TestSeed02 = 2;
            const HolderSeed TestSeed03 = 3;
            const HolderSeed TestSeed05 = 5;

            ISourceValues values = new ArticleEmptySource();

            IArticleHolder prepArticle1 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed01, values);
            IArticleHolder backArticle2 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed02, values);
            IArticleHolder backArticle3 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed03, values);
            IArticleHolder backArticle5 = testBucket.StoreGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, TestSeed05, values);

            IArticleHolder testArticle = testBucket.AddGeneralItem(HEAD_CODE_NULL, PART_CODE_NULL, BODY_CODE_TEST, BODY_SEED_NULL, values);
            string testArticleLabel = "0-0-TARGET_UNKNOWN-4";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCodeCz>());
        }

        private static ISourceCollection<IArticleSource, ConfigCode, ISourceValues> InitConfigModel()
        {
            Assembly configAssembly = typeof(ElementsService).Assembly;
            IArticleSourceFactory configFactory = new ArticleSourceFactory();
            ISourceCollection<IArticleSource, ConfigCode, ISourceValues> configTemplate = new ArticleStubCollection();

            configTemplate.InitConfigModel(configAssembly, configFactory);

            return configTemplate;
        }
    }
}