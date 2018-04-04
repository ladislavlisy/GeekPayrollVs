using System;
using NUnit.Framework;
using System.Reflection;
using ElementsLib;
using ElementsLib.Module.Codes;
using ElementsLib.Module.Interfaces.Elements;
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

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            IArticleSource testSource = configFactory.CreateSourceItem(configAssembly, (UInt16)ArticleCode.ARTCODE_CONTRACT_TERM, (UInt16)ArticleCode.ARTCODE_UNKNOWN);

            Assert.AreEqual(testTargetLabel, testSource.ToString());
        }
    }
}
