using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test_CodeLight
{
	[TestFixture ()]
	public class Test
	{
        IFileIndexer fileindexer;
        
        [SetUp]
        public void Setup() {
            var filter = new keyWordsFilter();
            this.fileindexer = new FileIndexer(filter);
        }

        [Test]
        public void ClassDirectoryIndexer()
        {
            string[] paths = { @"..\..\..\TestFiles\Extra2",
                               @"..\..\..\TestFiles\Extra5"};
            List<string> filesResult = FileSystemUtilities.GetFiles(paths);
            Assert.AreEqual(filesResult.Count, 5);
        }

        [Test()]
        public void Filter() {
            var filter = new keyWordsFilter();
            Assert.AreEqual(filter.ShouldKeep("hola"), true);
            Assert.AreEqual(filter.ShouldKeep("while"), false);
        }
        
	}
}

