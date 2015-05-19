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
        Dictionary<string, int> words;

        [SetUp]
        public void Setup()
        {
            var words = new Dictionary<string, int>();
        }

        [Test]
        public void GetWords() {
            words = FileIndexerUtilities.GetWords("Prueba en solo una linea");
            Assert.That(words.Count, Is.EqualTo(5));
            Assert.That(words.ContainsKey("en"));
            Assert.That(words["linea"], Is.EqualTo(20));
            Assert.That(words["en"], Is.EqualTo(8));
        }

        [Test]
        public void EmptyLine() {
            words = FileIndexerUtilities.GetWords("");
            Assert.AreEqual(words.Count,1);
            Assert.That(words.ContainsKey(""));
            Assert.AreEqual(words[""], 1);
        }
    
    }
}
