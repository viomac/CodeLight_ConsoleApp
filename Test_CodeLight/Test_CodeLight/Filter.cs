using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_CodeLight
{
    [TestFixture]
    public class Filter
    {
        [Test]
        public void keywordsFilter()
        {
            var filter = new KeywordsFilter();
            Assert.AreEqual(filter.ShouldKeep("hola"), true);
            Assert.AreEqual(filter.ShouldKeep("while"), false);
        }
    }
}
