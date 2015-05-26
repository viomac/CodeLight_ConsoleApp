using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_CodeLight
{
    [TestFixture]
    class FileIndexerMethods
    {
        IWordFilter wordFilter;
        IWordSplitter getWords;
        IFileIndexer indexer;
        IWordDictionary dict;

        [SetUp]
        public void setup()
        {
            wordFilter = new KeywordsFilter();
            getWords = new WordSplitter();
            indexer = new FileIndexer(wordFilter, getWords);
            dict = new WordDictionary();
        }

        [Test]
        public void indexFile()
        {
            string path = @"..\..\..\TestFiles\Dictionary.txt";
            indexer.IndexFile(path, ref dict);
            Assert.AreEqual(dict.dictionary.Count, 29); 
        }


    }
}
