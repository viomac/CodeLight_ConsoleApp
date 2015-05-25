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
        IGetWords words;

        [SetUp]
        public void Setup()
        {
            words = new GetWords();
        }
        
        [Test]
        public void wordsByLine()
        {
            Dictionary<string, int> wordList = words.getWords("Separa una linea en palabras...");
            Assert.AreEqual(wordList.Count, 5);
            Assert.That(wordList.ContainsKey("linea"), Is.True);
            Assert.That(wordList.ContainsKey("palabras..."), Is.True);
            Assert.That(wordList["una"] ,Is.EqualTo(8));
            Assert.That(wordList["en"], Is.EqualTo(18));
        }
        
        [Test]
        public void EmptyLine() {
            Dictionary<string, int> wordList = words.getWords("");
            Assert.AreEqual(wordList.Count,1);
            Assert.That(wordList.ContainsKey(""));
            Assert.AreEqual(wordList[""], 1);
        } 

    }
}
