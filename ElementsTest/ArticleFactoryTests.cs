using System;
using NUnit.Framework;
using System.Reflection;
using ElementsLib;
using ElementsLib.Module.Codes;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Elements.Config;
using ElementsLib.Elements;
using ElementsLib.Matrixus.Source;

namespace ElementsTest
{
    using ConfigCodeEnum = ArticleCodeCz;

    [TestFixture]
    public class ArticleFactoryTests
    {
        [Test]
        public void Test_CreateArticleTarget()
        {
            string testTargetLabel = "ARTCODE_CONTRACT_TERM";

            Assembly configAssembly = typeof(ElementsService).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            IArticleSource testSource = configFactory.CreateSourceItem(configAssembly, (UInt16)ConfigCodeEnum.ARTCODE_CONTRACT_TERM, (UInt16)ConfigCodeEnum.ARTCODE_UNKNOWN);

            Assert.AreEqual(testTargetLabel, testSource.ToString());
        }
    }
}
