using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ElementsLib;
using System.Reflection;
using ElementsLib.ModuleConfig.Codes;

namespace ElementsTest
{
    using ArticleCode = ArticleCzCode;

    using ElementsLib.Interfaces;
    using ElementsLib.ModuleBucket;

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
