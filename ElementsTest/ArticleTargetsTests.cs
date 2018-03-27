using System;
using NUnit.Framework;
using ElementsLib;

namespace ElementsTest
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using ExtendedCode = UInt16;
    using ExtendedSeed = UInt16;

    using ElementsLib.Interfaces;

    [TestFixture]
    public class ArticleTargetsTests
    {
        const ContractCode CONTRACT_NULL = 0;
        const PositionCode POSITION_NULL = 0;
        const ExtendedSeed TARGET_SEED_NULL = 0;
        const ExtendedCode TestTargetCode = (UInt16)PayrollCzCode.ARTCODE_UNKNOWN;

        [Test]
        public void Test_CreateArticleTarget()
        {
            ArticleTarget testArticle = new ArticleTarget(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-0";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
        [Test]
        public void Test_AddTargetToEmptyDict()
        {
            ArticleBucket testBucket = new ArticleBucket();

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBack()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const ExtendedSeed TestFirstSeed = 1;

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestFirstSeed);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFront()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const ExtendedSeed TestFirstSeed = 2;

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestFirstSeed);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictBetween()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const ExtendedSeed TestSeed01 = 1;
            const ExtendedSeed TestSeed02 = 3;
            const ExtendedSeed TestSeed03 = 4;

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed01);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed02);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed03);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBackNonEmpty()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const ExtendedSeed TestSeed01 = 1;
            const ExtendedSeed TestSeed02 = 2;
            const ExtendedSeed TestSeed03 = 3;
            const ExtendedSeed TestSeed04 = 4;

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed01);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed02);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed03);
            ArticleTarget backArticle4 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed04);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-5";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFrontNonEmpty()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const ExtendedSeed TestSeed01 = 1;
            const ExtendedSeed TestSeed02 = 2;
            const ExtendedSeed TestSeed03 = 3;
            const ExtendedSeed TestSeed05 = 5;

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed01);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed02);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed03);
            ArticleTarget backArticle5 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TestSeed05);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TestTargetCode, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-4";
            Assert.AreEqual(testArticleLabel, testArticle.SymbolDescription<PayrollCzCode>());
        }
    }
}