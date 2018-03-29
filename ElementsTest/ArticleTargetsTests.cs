﻿using System;
using NUnit.Framework;
using ElementsLib.Module.Codes;
using ElementsLib.Elements;

namespace ElementsTest
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;

    using ConfigCode = UInt16;
    using SymbolCode = ArticleCzCode;
    using TargetSeed = UInt16;

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
            ArticleBucket testBucket = new ArticleBucket();

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBack()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const TargetSeed TestFirstSeed = 1;

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestFirstSeed);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFront()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const TargetSeed TestFirstSeed = 2;

            ArticleTarget prepArticle = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestFirstSeed);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-1";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictBetween()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 3;
            const TargetSeed TestSeed03 = 4;

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed01);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed02);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed03);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-2";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToBackNonEmpty()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 2;
            const TargetSeed TestSeed03 = 3;
            const TargetSeed TestSeed04 = 4;

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed01);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed02);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed03);
            ArticleTarget backArticle4 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed04);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-5";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
        [Test]
        public void Test_AddSecondTargetToDictToFrontNonEmpty()
        {
            ArticleBucket testBucket = new ArticleBucket();

            const TargetSeed TestSeed01 = 1;
            const TargetSeed TestSeed02 = 2;
            const TargetSeed TestSeed03 = 3;
            const TargetSeed TestSeed05 = 5;

            ArticleTarget prepArticle1 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed01);
            ArticleTarget backArticle2 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed02);
            ArticleTarget backArticle3 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed03);
            ArticleTarget backArticle5 = testBucket.StoreGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TestSeed05);

            ArticleTarget testArticle = testBucket.AddGeneralItem(CONTRACT_NULL, POSITION_NULL, TARGET_CODE_TEST, TARGET_SEED_NULL);
            string testArticleLabel = "0-0-ARTCODE_UNKNOWN-4";
            Assert.AreEqual(testArticleLabel, testArticle.ToSymbolString<ArticleCzCode>());
        }
    }
}