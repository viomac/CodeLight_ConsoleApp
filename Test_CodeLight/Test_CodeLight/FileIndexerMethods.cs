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
            Assert.AreEqual(dict.dictionary.Count, 24);
			Assert.AreEqual (dict.dictionary["lookups"][path][1].Count,1);

			Dictionary<string, Dictionary<int, List<int>>> ocurrences = dict.Lookfor ("keys");
			Assert.That (ocurrences.ContainsKey (path));
			Assert.AreEqual (ocurrences[path][3], new List<int>(){10,49});

			ocurrences = dict.Lookfor ("lookups");
			Assert.AreEqual (ocurrences[path].Count,2);
			Assert.AreEqual (ocurrences[path][1], new List<int>(){18});
			Assert.AreEqual (ocurrences[path][2], new List<int>(){27});
        }


    }
}
