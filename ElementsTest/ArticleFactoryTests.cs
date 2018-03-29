using System;
using NUnit.Framework;
using System.Reflection;
using ElementsLib;
using ElementsLib.Module.Codes;
using ElementsLib.Module.Interfaces;
using ElementsLib.Elements.Config;

namespace ElementsTest
{
    using ArticleCode = ArticleCzCode;

    [TestFixture]
    public class ArticleFactoryTests
    {
        [Test]
        public void Test_CreateArticleTarget()
        {
            string testTargetLabel = "ARTCODE_CONTRACT_TERM";

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSource testSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, ArticleCode.ARTCODE_CONTRACT_TERM.GetSymbol());

            Assert.AreEqual(testTargetLabel, testSource.ToString());
        }
    }
}
