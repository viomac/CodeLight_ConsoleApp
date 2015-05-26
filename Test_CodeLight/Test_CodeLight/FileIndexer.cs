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
    class FileIndexer
    {
        IWordFilter filter;
        IGetWords words;
        IFileIndexer indexer;

        [SetUp]
        public void setup() 
        {
            filter  = new KeywordsFilter();
            words = new GetWords();
            //indexer = new FileIndexer(filter,words);
        }

        [Test]
        public void indexFile() 
        {

        }
    }
}
