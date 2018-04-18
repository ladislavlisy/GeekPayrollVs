using System;
using NUnit.Framework;
using System.Reflection;
using ElementsLib;
using ElementsLib.Module.Codes;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Elements.Config;
using ElementsLib.Elements;

namespace ElementsTest
{
    using ElementsLib.Matrixus.Config;
    using ElementsLib.Module.Interfaces.Matrixus;
    using ConfigRoleEnum = ArticleRoleCz;

    [TestFixture]
    public class ArticleFactoryTests
    {
        [Test]
        public void Test_CreateArticleTarget()
        {
            string testTargetLabel = "ARTICLE_CONTRACT_TERM";

            Assembly configAssembly = typeof(ElementsService).Assembly;

            IArticleConfigFactory configFactory = new ArticleConfigFactory();

            IArticleSource testSource = configFactory.CreateSourceClassStub(configAssembly, (UInt16)ConfigRoleEnum.ARTICLE_CONTRACT_TERM, ConfigRoleEnum.ARTICLE_CONTRACT_TERM.GetSymbol());

            Assert.AreEqual(testTargetLabel, testSource.ToString());
        }
    }
}
