using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ElementsLib;
using System.Reflection;

namespace ElementsTest
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = ArticleCode;
    using TargetSeed = UInt16;

    [TestFixture]
    public class ArticleFactoryTests
    {
        [Test]
        public void Test_CreateArticleTarget()
        {
            string testTargetLabel = "ARTICLE_CONTRACT_TERM";

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSource testSource = ArticleSourceFactory.ArticleSourceFor(configAssembly, TargetCode.ARTICLE_CONTRACT_TERM.GetSymbol());

            Assert.AreEqual(testTargetLabel, testSource.ToString());
        }
    }
}
