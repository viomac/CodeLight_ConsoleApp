using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test_CodeLight
{
	[TestFixture ()]
	public class Test
	{
        IDirectoryIndexer directories;
        IFileIndexer fileindexer;
        
        [SetUp]
        public void Setup() {
            this.directories = new DirectoryIndexer();
            var filter = new WordFilter();
            this.fileindexer = new FileIndexer(filter);
        }

        [Test()]
        public void Test_ClassDirectoryIndexer()
        {
            string[] paths = { @"..\..\..\TestFiles\Extra2",
                               @"..\..\..\TestFiles\Extra5"};
            string[] filesResult = this.directories.GetFiles(paths);
            Assert.AreEqual(filesResult.Length, 5);
        }

        [Test()]
        public void Test_Filter() {
            var filter = new WordFilter();
            Assert.AreEqual(filter.ContainsWord("hola"), false);
            Assert.AreEqual(filter.ContainsWord("while"), true);
        }




	}
}

