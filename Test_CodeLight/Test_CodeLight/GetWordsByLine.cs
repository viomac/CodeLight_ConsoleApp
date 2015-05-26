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
    public class GetWordsByLine
    {
        IWordSplitter words;

        [SetUp]
        public void Setup()
        {
            words = new WordSplitter();
        }
        
        [Test]
        public void wordsByLine()
        {
            Dictionary<string, int> wordList = words.SplitIntoWords("Separa una linea en palabras...");
            Assert.AreEqual(wordList.Count, 5);
            Assert.That(wordList.ContainsKey("linea"));
            Assert.That(wordList.ContainsKey("palabras..."));
            Assert.That(wordList["una"] ,Is.EqualTo(8));
            Assert.That(wordList["en"], Is.EqualTo(18));
        }
        
        [Test]
        public void EmptyLine() {
            Dictionary<string, int> wordList = words.SplitIntoWords("");
            Assert.AreEqual(wordList.Count,1);
            Assert.That(wordList.ContainsKey(""));
            Assert.AreEqual(wordList[""], 1);
        } 
        
    }
}
