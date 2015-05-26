using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test_CodeLight
{
	[TestFixture ()]
	public class DirectoryIndexer
	{
        //IFileIndexer fileindexer;
        
        [SetUp]
        public void Setup() {
            var filter = new KeywordsFilter();
            //this.fileindexer = new FileIndexer(filter);
        }

        [Test]
        public void ClassDirectoryIndexer()
        {
            string[] paths = { @"..\..\..\TestFiles\Extra2",
                               @"..\..\..\TestFiles\Extra5"};
            List<string> filesResult = FileSystemUtilities.GetAllFiles(paths);
            Assert.AreEqual(filesResult.Count, 5);
        }       
        
	}
}

